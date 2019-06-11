using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands
{
    public abstract class ApiSecretCommand : Command
    {
        public int Id { get; protected set; }
        public string ApiResourceName { get; protected set; }
        public string Description { get; protected set; }
        public string Value { get; protected set; }
        public DateTime? Expiration { get; protected set; }
        public string Type { get; protected set; }
        public int HashType { get; protected set; } = 0;
    }
}
