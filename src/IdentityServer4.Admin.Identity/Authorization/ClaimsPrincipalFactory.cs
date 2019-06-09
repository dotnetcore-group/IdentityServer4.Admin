using IdentityServer4.Admin.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Identity.Authorization
{
    public sealed class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public ClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, roleManager, optionsAccessor)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user).ConfigureAwait(false);

            if (!identity.HasClaim(x => x.Type == "sub"))
            {
                var sub = user.Id.ToString();
                identity.AddClaim(new Claim("sub", sub));
            }

            return identity;
        }
    }
}
