using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.Services;
using IdentityServer4.Admin.BuildingBlock.Bus;
using IdentityServer4.Admin.Data;
using IdentityServer4.Admin.Data.Database;
using IdentityServer4.Admin.Data.Repositories;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Authorization;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application Services
            services.AddScoped<IClientService, ClientService>()
                .AddScoped<IUserService, UserService>();

            // Domain Events

            // Domain Commands

            // Repositories
            services.AddScoped<IDS4DbContext>()
                .AddScoped<EventStoreContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IEventStoreRepository, EventStoreRepository>();
        }
    }
}
