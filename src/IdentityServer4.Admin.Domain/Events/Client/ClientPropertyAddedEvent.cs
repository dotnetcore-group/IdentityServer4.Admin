using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.Client
{
    public class ClientPropertyAddedEvent : Event
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ClientPropertyAddedEvent(string clientId, int id, string key, string value)
        {
            AggregateId = clientId;
            Id = id;
            Value = value;
            Key = key;
        }
    }
}
