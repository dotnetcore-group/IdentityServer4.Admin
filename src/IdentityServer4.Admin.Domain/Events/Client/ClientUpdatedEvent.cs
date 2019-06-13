using IdentityServer4.Admin.Domain.Commands.Client;
using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientUpdatedEvent : Event
    {
        public UpdateClientCommand Command { get; set; }
        public ClientUpdatedEvent(UpdateClientCommand command)
        {
            Command = command;
            AggregateId = command.Client.ClientId;
        }
    }
}
