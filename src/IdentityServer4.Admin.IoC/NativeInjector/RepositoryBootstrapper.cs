using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Admin.Data;
using IdentityServer4.Admin.Data.Database;
using IdentityServer4.Admin.Data.EventSourcing;
using IdentityServer4.Admin.Data.Repositories;
using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.IoC
{
    public class RepositoryBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDS4DbContext>()
                .AddScoped<EventStoreContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IEventStoreRepository, EventStoreRepository>()
                .AddScoped<IEventStore, DbEventStore>()
                .AddScoped<IStartupRepository, StartupRepository>()
                .AddScoped<ILoginLogRepository, LoginLogRepository>()
                .AddScoped<IClientRepository, ClientRepository>()
                .AddScoped<IClientSecretRepository, ClientSecretRepository>()
                .AddScoped<IClientClaimRepository, ClientClaimRepository>()
                .AddScoped<IClientPropertyRepository, ClientPropertyRepository>()
                .AddScoped<IApiResourceRepository, ApiResourceRepository>()
                .AddScoped<IIdentityResourceRepository, IdentityResourceRepository>()
                .AddScoped<IApiSecretRepository, ApiSecretRepository>()
                .AddScoped<IApiScopeRepository, ApiScopeRepository>();
        }
    }
}
