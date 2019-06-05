using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.Services
{
    public class UserService : IUserService
    {
        public Task AddLogin(SocialViewModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> FindByEmailAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> FindByNameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> FindByProviderAsync(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberLogin, bool lockoutOnFailure)
        {
            throw new NotImplementedException();
        }

        public Task RegisterWithoutPassword(SocialViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
