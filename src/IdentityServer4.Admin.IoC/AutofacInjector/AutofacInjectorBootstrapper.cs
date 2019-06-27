using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4.Admin.BuildingBlock.Bus;
using IdentityServer4.Admin.BuildingBlock.Drawing;
using IdentityServer4.Admin.BuildingBlock.Email;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Identity.Authorization;
using IdGen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.IoC.AutofacInjector
{
    public static class AutofacInjectorBootstrapper
    {
        public static IServiceProvider RegisterServices(IServiceCollection services)
        {
            var container = new ContainerBuilder();
            container.Populate(services);

            // HttpContext dependency
            container.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .InstancePerLifetimeScope();

            // Domain Bus (Mediator)
            container.RegisterType<InMemoryBus>()
               .As<IMediatorHandler>()
               .InstancePerLifetimeScope();

            // Email Service
            container.RegisterType<RandomDrawing>()
               .SingleInstance();
            container.Register<IIdGenerator<long>>(c=>new IdGenerator(0))
               .SingleInstance();
            container.RegisterType<EmailSender>()
                .As<IEmailSender>();

            // Authorization Polices
            container.RegisterType<ClaimsRequirementHandler>()
                .As<IAuthorizationHandler>()
               .SingleInstance();

            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ApplicationModule());
            container.RegisterModule(new RepositoryModule());

            return new AutofacServiceProvider(container.Build());
        }
    }
}
