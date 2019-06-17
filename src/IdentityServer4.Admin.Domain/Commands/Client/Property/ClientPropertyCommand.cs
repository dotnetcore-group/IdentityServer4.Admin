using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client
{
    public abstract class ClientPropertyCommand : Command
    {
        public string ClientId { get; protected set; }
        public int Id { get; protected set; }

        public string Key { get; protected set; }
        public string Value { get; protected set; }
    }
}
