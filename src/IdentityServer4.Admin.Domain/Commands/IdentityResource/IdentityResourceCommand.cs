using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.IdentityResource
{
    public abstract class IdentityResourceCommand : Command
    {
        public IdentityServer4.Models.IdentityResource IdentityResource { get; protected set; }

        public string OldIdentityResourceName { get; protected set; }
    }
}
