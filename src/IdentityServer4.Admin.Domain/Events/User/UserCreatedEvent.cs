using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.User
{
    public class UserCreatedEvent : Event
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public long Uid { get; set; }
        public UserCreatedEvent(string userId, string username, string email, long uid)
        {
            AggregateId = userId;
            UserName = username;
            Email = email;
            Uid = uid;
        }
    }
}
