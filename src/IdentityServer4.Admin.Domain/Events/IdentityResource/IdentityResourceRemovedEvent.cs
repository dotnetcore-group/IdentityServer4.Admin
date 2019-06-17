using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.IdentityResource
{
    public class IdentityResourceRemovedEvent : Event
    {
        public IdentityResourceRemovedEvent(int id)
        {
            AggregateId = id.ToString();
        }
    }
}
