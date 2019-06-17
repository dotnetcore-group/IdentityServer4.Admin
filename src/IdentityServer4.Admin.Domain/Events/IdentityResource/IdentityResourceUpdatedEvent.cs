using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.IdentityResource
{
    public class IdentityResourceUpdatedEvent : Event
    {
        public string NewName { get; set; }
        public string OldName { get; set; }

        public IdentityResourceUpdatedEvent(int id, string newName, string oldName)
        {
            AggregateId = id.ToString();
            NewName = newName;
            OldName = oldName;
        }
    }
}
