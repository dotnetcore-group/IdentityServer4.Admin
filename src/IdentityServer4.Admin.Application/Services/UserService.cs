using AutoMapper;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Domain.Commands;
using IdentityServer4.Admin.Domain.Commands.User;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class UserService : IUserAppService
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        public UserService(IUserManager userManager,
            IMapper mapper,
            IMediatorHandler bus)
        {
            _userManager = userManager;
            _mapper = mapper;
            _bus = bus;
        }

        public async Task AddLogin(SocialViewModel user)
        {
            var command = _mapper.Map<AddLoginCommand>(user);
            await _bus.SendCommand(command);
        }

        public async Task<bool> CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return (await _userManager.FindByEmailAsync(email)) != null;
        }

        public async Task<bool> CheckUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            return (await _userManager.FindByNameAsync(username)) != null;
        }

        public Task ConfirmEmailAsync(string email, string token)
        {
            var command = new ConfirmEmailCommand(email, token);
            return _bus.SendCommand(command);
        }

        public Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user)
        {
            return _userManager.CreateUserPrincipalAsync(user);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser> FindByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<UserViewModel> FindByProviderAsync(string provider, string providerUserId)
        {
            var user = await _userManager.FindByLoginAsync(provider, providerUserId);
            if (user != null)
            {
                return _mapper.Map<UserViewModel>(user);
            }
            return null;
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberLogin, bool lockoutOnFailure)
        {
            return await _userManager.PasswordSignInAsync(userName, password, rememberLogin, lockoutOnFailure: true);
        }

        public async Task RegisterAsync(RegisterUserViewModel user)
        {
            var command = _mapper.Map<RegisterNewUserCommand>(user);
            await _bus.SendCommand(command);
        }

        public async Task RegisterWithoutPassword(SocialViewModel user)
        {
            var command = _mapper.Map<RegisterNewUserWithoutPassCommand>(user);
            await _bus.SendCommand(command);
        }
    }
}
