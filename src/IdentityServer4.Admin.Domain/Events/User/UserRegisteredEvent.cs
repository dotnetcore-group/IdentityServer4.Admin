using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.User
{
    public class UserRegisteredEvent : Event
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public UserRegisteredEvent(Guid aggregateId, string userName, string email)
        {
            AggregateId = aggregateId;
            UserName = userName;
            Email = email;
        }
    }
}
