using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Nickname { get; protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public string ConfirmPassword { get; protected set; }
        public string Provider { get; protected set; }
        public string ProviderId { get; protected set; }
        public bool EmailConfirmed { get; protected set; }
        public bool PhoneNumberConfirmed { get; protected set; }
        public bool TwoFactorEnabled { get; protected set; }
        public DateTimeOffset? LockoutEnd { get; protected set; }
        public bool LockoutEnabled { get; protected set; }
        public int AccessFailedCount { get; protected set; }
        public string Token { get; protected set; }

    }
}
