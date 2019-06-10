using IdentityModel;
using IdentityServer4.Admin.BuildingBlock.Drawing;
using IdentityServer4.Admin.BuildingBlock.Email;
using IdentityServer4.Admin.Domain.Commands;
using IdentityServer4.Admin.Domain.Commands.User;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Events.User;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using IdGen;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserWithoutPassCommand, bool>,
        IRequestHandler<RegisterNewUserCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IIdGenerator<long> _idGenerator;
        private readonly RandomDrawing _drawing;
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        public UserCommandHandler(IUnitOfWork uow,
            IMediatorHandler bus,
            RandomDrawing drawing,
            IConfiguration config,
            INotificationHandler<DomainNotification> notifications,
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender,
            IHostingEnvironment env,
            IIdGenerator<long> idGenerator) : base(uow, bus, notifications)
        {
            _config = config;
            _userManager = userManager;
            _emailSender = emailSender;
            _idGenerator = idGenerator;
            _drawing = drawing;
            _env = env;
        }

        public async Task<bool> Handle(RegisterNewUserWithoutPassCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Username,
                PhoneNumber = request.PhoneNumber,
                Uid = _idGenerator.CreateId()
            };

            if (!string.IsNullOrEmpty(user.Email))
            {
                var emailAlreadyExist = await _userManager.FindByEmailAsync(user.Email);
                if (emailAlreadyExist != null)
                {
                    await _bus.RaiseEvent(new DomainNotification("1001", "E-mail already exist. If you don't remember your passwork, reset it."));
                    return false;
                }
            }

            var usernameAlreadyExist = await _userManager.FindByNameAsync(user.UserName);

            if (usernameAlreadyExist != null)
            {
                await _bus.RaiseEvent(new DomainNotification("1002", "Username already exist. If you don't remember your passwork, reset it."));
                return false;
            }

            var id = await CreateUserWithProvider(user, request.Provider, request.ProviderId);
            if (id.HasValue)
            {
                await _bus.RaiseEvent(new UserRegisteredEvent(id.Value, user.UserName, user.Email));
                return true;
            }
            return false;

        }

        public async Task<bool> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return false;
            }
            var uid = _idGenerator.CreateId();
            var avatar = GetAvatar(uid);
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Username,
                Nickname = request.Nickname,
                PhoneNumber = request.PhoneNumber,
                Uid = uid,
                Avatar = avatar
            };

            var emailAlreadyExist = await _userManager.FindByEmailAsync(user.Email);
            if (emailAlreadyExist != null)
            {
                await _bus.RaiseEvent(new DomainNotification("1001", "E-mail already exist. If you don't remember your passwork, reset it."));
                return false;
            }
            var usernameAlreadyExist = await _userManager.FindByNameAsync(user.UserName);

            if (usernameAlreadyExist != null)
            {
                await _bus.RaiseEvent(new DomainNotification("1002", "Username already exist. If you don't remember your passwork, reset it."));
                return false;
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.UserName, user.Email));
                return true;
            }
            return false;
        }

        private async Task<Guid?> CreateUserWithProvider(ApplicationUser user, string provider, string providerId)
        {
            if (!string.IsNullOrEmpty(provider))
            {
                var userByProvider = await _userManager.FindByLoginAsync(provider, providerId);
                if (userByProvider != null)
                    await _bus.RaiseEvent(new DomainNotification("1001", $"User already taken with {provider}"));
            }
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = $"https://localhost:5005/account/confirm-email?user={user.Email.UrlEncode()}&code={code.UrlEncode()}";
                    await _emailSender.SendEmailConfirmationAsync(user.Email, callbackUrl);
                }

                await AddClaims(user);

                if (!string.IsNullOrWhiteSpace(provider))
                {
                    await AddLoginAsync(user, provider, providerId);
                }

                return user.Id;
            }

            foreach (var error in result.Errors)
            {
                await _bus.RaiseEvent(new DomainNotification(result.ToString(), error.Description));
            }

            return null;
        }

        private async Task AddClaims(ApplicationUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", user.UserName));
            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(JwtClaimTypes.Email, user.Email));
            }

            var identityResult = await _userManager.AddClaimsAsync(user, claims);
        }

        private async Task<bool> AddLoginAsync(ApplicationUser user, string provider, string providerUserId)
        {
            var result = await _userManager.AddLoginAsync(user, new UserLoginInfo(provider, providerUserId, provider));

            foreach (var error in result.Errors)
            {
                await _bus.RaiseEvent(new DomainNotification(result.ToString(), error.Description));
            }

            return result.Succeeded;
        }

        private string GetAvatar(long uid)
        {
            var domain = _config.GetValue("DomainPath", "https://localhost:5005");
            var requestPath = PathUtils.CombinePaths("files", "avatars", DateTime.UtcNow.ToString("yyyyMM"));
            var savePath = PathUtils.CombinePaths(_env.ContentRootPath, requestPath);
            var filePath = PathUtils.CombinePaths(savePath, $"{uid}.jpg");
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }
            using (var avatar = _drawing.Generate(200, 200))
            {
                avatar.Seek(0, SeekOrigin.Begin);
                using (var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    avatar.CopyTo(file);
                }
            }
            return PathUtils.CombinePaths(domain, requestPath, $"{uid}.jpg");
        }
    }
}
