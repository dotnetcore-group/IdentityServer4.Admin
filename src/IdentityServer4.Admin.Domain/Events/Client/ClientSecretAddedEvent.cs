using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientSecretAddedEvent : Event
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public ClientSecretAddedEvent(string clientId, int id, string value, string type, string description)
        {
            AggregateId = clientId;
            Id = id;
            Value = value;
            Type = type;
            Description = description;
        }
    }
}
