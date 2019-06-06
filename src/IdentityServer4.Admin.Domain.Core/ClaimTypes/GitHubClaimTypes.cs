using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Core.ClaimTypes
{
    public class GitHubClaimTypes
    {
        public const string UserName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public const string Name = "urn:github:name";
        public const string Url = "urn:github:url";
    }
}
