using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.Services;
using IdentityServer4.Admin.BuildingBlock.Bus;
using IdentityServer4.Admin.BuildingBlock.Drawing;
using IdentityServer4.Admin.BuildingBlock.Email;
using IdentityServer4.Admin.Data;
using IdentityServer4.Admin.Data.Database;
using IdentityServer4.Admin.Data.EventSourcing;
using IdentityServer4.Admin.Data.Repositories;
using IdentityServer4.Admin.Domain.CommandHandlers;
using IdentityServer4.Admin.Domain.Commands;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Commands.User;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.EventHandlers;
using IdentityServer4.Admin.Domain.Events.User;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Authorization;
using IdentityServer4.Admin.Identity.Entities;
using IdentityServer4.Admin.Infrastructures.Data.Database;
using IdGen;
using MediatR;
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
                .AddScoped<IEmailSender, EmailSender>();

            // Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application Services
            services.AddScoped<IClientService, ClientService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IUserManagerService, UserManagerService>()
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IApiResourceService, ApiResourceService>()
                .AddScoped<IIdentityResourceService, IdentityResourceService>()
                .AddScoped<SystemUser>();

            // Domain Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
                .AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>()
                .AddScoped<INotificationHandler<NewLoginAddedEvent>, UserEventHandler>();

            // Domain Commands
            services.AddScoped<IRequestHandler<RegisterNewUserWithoutPassCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<RegisterNewUserCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<AddLoginCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<SetApiSecretCommand, bool>, ApiResourceCommandHandler>()
                .AddScoped<IRequestHandler<SetApiScopeCommand, bool>, ApiResourceCommandHandler>()
                .AddScoped<IRequestHandler<CreateClientCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<RemoveClientCommand, bool>, ClientCommandHandler>();

            // Repositories
            services.AddScoped<IDS4DbContext>()
                .AddScoped<EventStoreContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IEventStoreRepository, EventStoreRepository>()
                .AddScoped<IEventStore, DbEventStore>()
                .AddScoped<IClientRepository, ClientRepository>()
                .AddScoped<IClientSecretRepository, ClientSecretRepository>()
                .AddScoped<IClientClaimRepository, ClientClaimRepository>()
                .AddScoped<IApiResourceRepository, ApiResourceRepository>()
                .AddScoped<IIdentityResourceRepository, IdentityResourceRepository>()
                .AddScoped<IApiSecretRepository, ApiSecretRepository>()
                .AddScoped<IApiScopeRepository, ApiScopeRepository>();
        }
    }
}
