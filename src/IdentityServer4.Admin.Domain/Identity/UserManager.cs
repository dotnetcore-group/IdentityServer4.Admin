using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Identity
{
    public class UserManager : IUserManager
    {
        private readonly IMediatorHandler _bus;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserManager(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMediatorHandler bus)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _bus = bus;
        }

        public Task<IdentityResult> AddClaimsAsync(ApplicationUser user, List<Claim> claims)
        {
            return _userManager.AddClaimsAsync(user, claims);
        }

        public Task<IdentityResult> AddLoginAsync(ApplicationUser user, UserLoginInfo userLoginInfo)
        {
            return _userManager.AddLoginAsync(user, userLoginInfo);
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    return true;
                }
                foreach (var error in result.Errors)
                {
                    await _bus.RaiseEvent(new DomainNotification(result.ToString(), error.Description));
                }
            }
            else
            {
                await _bus.RaiseEvent(new DomainNotification("email_not_found", $"Unable to load user with Email '{email}'."));
            }
            return false;
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            return _userManager.CreateAsync(user);
        }

        public Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user)
        {
            return _signInManager.CreateUserPrincipalAsync(user);
        }

        public Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<ApplicationUser> FindByLoginAsync(string provider, string providerUserId)
        {
            return _userManager.FindByLoginAsync(provider, providerUserId);
        }

        public Task<ApplicationUser> FindByNameAsync(string username)
        {
            return _userManager.FindByNameAsync(username);
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberLogin, bool lockoutOnFailure)
        {
            return _signInManager.PasswordSignInAsync(userName, password, rememberLogin, lockoutOnFailure);
        }
    }
}
