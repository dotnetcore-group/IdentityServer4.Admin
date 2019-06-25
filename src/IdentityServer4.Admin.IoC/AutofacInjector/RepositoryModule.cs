using Autofac;
using IdentityServer4.Admin.Data;
using IdentityServer4.Admin.Data.Database;
using IdentityServer4.Admin.Data.EventSourcing;
using IdentityServer4.Admin.Data.Repositories;
using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using Microsoft.Extensions.Configuration;

namespace IdentityServer4.Admin.IoC.AutofacInjector
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IDS4DbContext>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EventStoreContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EventStoreRepository>()
                .As<IEventStoreRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<DbEventStore>()
                .As<IEventStore>()
                .InstancePerLifetimeScope();
            builder.RegisterType<StartupRepository>()
                .As<IStartupRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<LoginLogRepository>()
                .As<ILoginLogRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ClientRepository>()
                .As<IClientRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ClientSecretRepository>()
                .As<IClientSecretRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ClientClaimRepository>()
                .As<IClientClaimRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ClientPropertyRepository>()
                .As<IClientPropertyRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApiResourceRepository>()
                .As<IApiResourceRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApiSecretRepository>()
                .As<IApiSecretRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<IdentityResourceRepository>()
                .As<IIdentityResourceRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApiScopeRepository>()
                .As<IApiScopeRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
