using IdentityServer4.Admin.Application.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using IdentityServer4.Admin.Identity.Entities;

namespace IdentityServer4.Admin.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> FindByEmailAsync(string username);
        Task<ApplicationUser> FindByNameAsync(string username);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberLogin, bool lockoutOnFailure);
        Task<UserViewModel> FindByProviderAsync(string provider, string providerUserId);
        Task<bool> CheckUsername(string username);
        Task<bool> CheckEmail(string email);
        Task AddLogin(SocialViewModel user);
        Task RegisterWithoutPassword(SocialViewModel user);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user);
    }
}
