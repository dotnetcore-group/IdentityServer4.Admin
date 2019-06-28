using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ApplicationUser> FindByNameAsync(string username);
        Task<bool> ConfirmEmailAsync(string email, string token);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user);
        Task<ApplicationUser> FindByLoginAsync(string provider, string providerUserId);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberLogin, bool lockoutOnFailure);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> AddLoginAsync(ApplicationUser user, UserLoginInfo userLoginInfo);
        Task<IdentityResult> AddClaimsAsync(ApplicationUser user, List<Claim> claims);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
    }
}
