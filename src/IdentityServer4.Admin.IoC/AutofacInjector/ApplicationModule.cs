using Autofac;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.Services;
using IdentityServer4.Admin.Identity.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.IoC.AutofacInjector
{
    public class ApplicationModule : Autofac.Module
    {
        

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientService>()
                .As<IClientService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StartupService>()
                .As<IStartupService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserManagerService>()
                .As<IUserManagerService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RoleService>()
                .As<IRoleService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApiResourceService>()
                .As<IApiResourceService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<IdentityResourceService>()
                .As<IIdentityResourceService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SystemUser>()
                .InstancePerLifetimeScope();
        }
    }
}
