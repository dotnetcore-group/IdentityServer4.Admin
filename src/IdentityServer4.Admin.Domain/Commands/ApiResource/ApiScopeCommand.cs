using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands
{
    public abstract class ApiScopeCommand : Command
    {
        public int Id { get; protected set; }
        public string ApiResourceName { get; protected set; }
        public string Name { get; protected set; }
        public string DisplayName { get; protected set; }
        public string Description { get; protected set; }
        public bool Required { get; protected set; } = false;
        public bool Emphasize { get; protected set; } = false;
        public bool ShowInDiscoveryDocument { get; protected set; } = true;
        public IEnumerable<string> UserClaims { get; protected set; } = new HashSet<string>();
    }
}
