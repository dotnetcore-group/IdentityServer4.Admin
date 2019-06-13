using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.ApiResource
{
    public class ApiResourceRemovedEvent : Event
    {
        public ApiResourceRemovedEvent(string name)
        {
            AggregateId = name;
        }
    }
}
