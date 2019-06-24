using IdentityServer4.Admin.BuildingBlock.Bus;
using IdentityServer4.Admin.BuildingBlock.Drawing;
using IdentityServer4.Admin.BuildingBlock.Email;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Identity.Authorization;
using IdGen;
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

            // Email Service
            services.AddSingleton<RandomDrawing>()
                .AddSingleton<IIdGenerator<long>>(p => new IdGenerator(0))
                .AddTransient<IEmailSender, EmailSender>();

            // Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application Services
            new ApplicationBootStrapper().RegisterServices(services);

            // Domain Events
            new DomainEventsBootStrapper().RegisterServices(services);

            // Domain Commands
            new DomainCommandsBootStrapper().RegisterServices(services);

            // Repositories
            new RepositoryBootStrapper().RegisterServices(services);
        }
    }
}
