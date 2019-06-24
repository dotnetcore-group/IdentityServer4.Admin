using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.EventHandlers;
using IdentityServer4.Admin.Domain.Events.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4.Admin.IoC
{
    public class DomainEventsBootStrapper : IBootStrapper
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
                .AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>()
                .AddScoped<INotificationHandler<UserLoggedInEvent>, UserEventHandler>()
                .AddScoped<INotificationHandler<NewLoginAddedEvent>, UserEventHandler>();
        }
    }
}
