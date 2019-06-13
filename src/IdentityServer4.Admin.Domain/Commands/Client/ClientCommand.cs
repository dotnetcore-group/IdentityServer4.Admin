using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client
{
    public abstract class ClientCommand : Command
    {
        public IdentityServer4.Models.Client Client { get; protected set; }
    }
}
