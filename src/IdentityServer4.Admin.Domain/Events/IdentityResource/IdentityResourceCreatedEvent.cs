using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.IdentityResource
{
    public class IdentityResourceCreatedEvent : Event
    {
        public string Name { get; set; }

        public IdentityResourceCreatedEvent(int id, string name)
        {
            AggregateId = id.ToString();
            Name = name;
        }
    }
}
