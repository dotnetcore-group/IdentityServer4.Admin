using IdentityServer4.Admin.Domain.Core.Events;
using IdentityServer4.Admin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientCreatedEvent : Event
    {
        public string ClientName { get; private set; }
        public ClientType ClientType { get; private set; }

        public ClientCreatedEvent(string clientId, string clientName, ClientType clientType)
        {
            AggregateId = clientId;
            ClientName = clientName;
            ClientType = clientType;
        }
    }
}
