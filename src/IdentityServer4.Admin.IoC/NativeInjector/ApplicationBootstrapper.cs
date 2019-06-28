using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.Services;
using IdentityServer4.Admin.Domain.Identity;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.IoC
{
    public class ApplicationBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>()
                .AddScoped<IStartupService, StartupService>()
                .AddScoped<IUserAppService, UserService>()
                .AddScoped<IUserManagerService, UserManagerService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IApiResourceService, ApiResourceService>()
                .AddScoped<IIdentityResourceService, IdentityResourceService>()
                .AddScoped<SystemUser>()
                .AddScoped<IUserManager, UserManager>();
        }
    }
}
