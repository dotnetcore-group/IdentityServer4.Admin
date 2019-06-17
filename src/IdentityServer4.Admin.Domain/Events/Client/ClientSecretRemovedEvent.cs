using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientSecretRemovedEvent : Event
    {
        public int Id { get; set; }
        public ClientSecretRemovedEvent(string clientId, int id)
        {
            AggregateId = clientId;
            Id = id;
        }
    }
}
