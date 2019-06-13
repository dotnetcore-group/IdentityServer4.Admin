using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.User
{
    public class NewLoginAddedEvent : Event
    {
        public string UserName { get; }
        public string Provider { get; }
        public string ProviderId { get; }

        public NewLoginAddedEvent(string aggregateId, string userName, string provider, string providerId)
        {
            UserName = userName;
            Provider = provider;
            ProviderId = providerId;
            AggregateId = aggregateId;
        }
    }
}
