using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientClaimAddedEvent : Event
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }

        public ClientClaimAddedEvent(string clientId, int id, string type, string value)
        {
            AggregateId = clientId;
            Id = id;
            Type = type;
            Value = value;
        }
    }
}
