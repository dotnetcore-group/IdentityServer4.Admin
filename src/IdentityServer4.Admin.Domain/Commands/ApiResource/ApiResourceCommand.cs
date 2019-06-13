using IdentityServer4.Admin.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.ApiResource
{
    public abstract class ApiResourceCommand : Command
    {
        public IdentityServer4.Models.ApiResource ApiResource { get; protected set; }
    }
}
