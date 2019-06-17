using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientClaimRemovedEvent :  Event
    {
        public int Id { get; set; }

        public ClientClaimRemovedEvent(string clientId, int id)
        {
            AggregateId = clientId;
            Id = id;
        }
    }
}
