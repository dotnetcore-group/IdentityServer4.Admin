using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.Services;
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
                .AddScoped<IUserService, UserService>()
                .AddScoped<IUserManagerService, UserManagerService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IApiResourceService, ApiResourceService>()
                .AddScoped<IIdentityResourceService, IdentityResourceService>()
                .AddScoped<SystemUser>();
        }
    }
}
