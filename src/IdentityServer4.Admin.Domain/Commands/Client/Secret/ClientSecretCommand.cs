using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client.Secret
{
    public abstract class ClientSecretCommand : Command
    {
        public int Id { get; protected set; }
        public string ClientId { get; protected set; }
        public string Description { get; protected set; }
        public string Value { get; protected set; }
        public DateTime? Expiration { get; protected set; }
        public int HashType { get; protected set; } = 0;
        public string Type { get; protected set; }
    }
}
