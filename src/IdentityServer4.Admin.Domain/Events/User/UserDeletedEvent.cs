using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.User
{
    public class UserDeletedEvent : Event
    {
        public UserDeletedEvent(string userId)
        {
            AggregateId = userId;
        }
    }
}
