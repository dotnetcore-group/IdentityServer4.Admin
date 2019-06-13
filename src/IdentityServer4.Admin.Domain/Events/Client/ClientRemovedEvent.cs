using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientRemovedEvent : Event
    {
        public ClientRemovedEvent(string clientId)
        {
            AggregateId = clientId;
        }
    }
}
