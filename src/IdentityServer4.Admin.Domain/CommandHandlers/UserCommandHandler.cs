using IdentityServer4.Admin.Domain.Commands;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserWithoutPassCommand, bool>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserCommandHandler(IUnitOfWork uow, IMediatorHandler bus, UserManager<ApplicationUser> userManager) : base(uow, bus)
        {
            _userManager = userManager;
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
                PhoneNumber = request.PhoneNumber
            };

            var emailAlreadyExist = await _userManager.FindByEmailAsync(user.Email);
            if (emailAlreadyExist != null)
            {
                //await Bus.RaiseEvent(new DomainNotification("1001", "E-mail already exist. If you don't remember your passwork, reset it."));
                return false;
            }
            var usernameAlreadyExist = await _userManager.FindByNameAsync(user.UserName);

            if (usernameAlreadyExist != null)
            {
                //await Bus.RaiseEvent(new DomainNotification("1002", "Username already exist. If you don't remember your passwork, reset it."));
                return false;
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                //await _bus.RaiseEvent(new UserRegisteredEvent(id.Value, user.Name, user.Email));
                return true;
            }
            return false;

        }
    }
}
