using IdentityServer4.Admin.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Events.User
{
    public class EmailConfirmedEvent : Event
    {
        public string Token { get; private set; }
        public EmailConfirmedEvent(string email, string token)
        {
            AggregateId = email;
            Token = token;
        }
    }
}
