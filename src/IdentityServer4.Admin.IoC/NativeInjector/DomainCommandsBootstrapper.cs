using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Admin.Domain.CommandHandlers;
using IdentityServer4.Admin.Domain.Commands;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Commands.Client.Claim;
using IdentityServer4.Admin.Domain.Commands.Client.Property;
using IdentityServer4.Admin.Domain.Commands.Client.Secret;
using IdentityServer4.Admin.Domain.Commands.IdentityResource;
using IdentityServer4.Admin.Domain.Commands.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.IoC
{
    public class DomainCommandsBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // User
            services.AddScoped<IRequestHandler<RegisterNewUserWithoutPassCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<CreateUserCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<DeleteUserCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<RegisterNewUserCommand, bool>, UserCommandHandler>()
                .AddScoped<IRequestHandler<AddLoginCommand, bool>, UserCommandHandler>();

            // ApiResource
            services.AddScoped<IRequestHandler<RemoveApiResourceCommand, bool>, ApiResourceCommandHandler>()
                .AddScoped<IRequestHandler<SetApiSecretCommand, bool>, ApiResourceCommandHandler>()
                .AddScoped<IRequestHandler<SetApiScopeCommand, bool>, ApiResourceCommandHandler>();

            // Client
            services.AddScoped<IRequestHandler<CreateClientCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<UpdateClientCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<RemoveClientCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<SaveClientPropertyCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<RemoveClientPropertyCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<SaveClientSecretCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<RemoveClientSecretCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<SaveClientClaimCommand, bool>, ClientCommandHandler>()
                .AddScoped<IRequestHandler<RemoveClientClaimCommand, bool>, ClientCommandHandler>();

            // IdentityResource
            services.AddScoped<IRequestHandler<CreateIdentityResourceCommand, bool>, IdentityResourceCommandHandler>()
                .AddScoped<IRequestHandler<RemoveIdentityResourceCommand, bool>, IdentityResourceCommandHandler>()
                .AddScoped<IRequestHandler<UpdateIdentityResourceCommand, bool>, IdentityResourceCommandHandler>();
        }
    }
}
