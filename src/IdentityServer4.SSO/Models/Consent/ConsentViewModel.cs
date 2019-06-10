using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Models.Consent
{
    public class ConsentViewModel : ConsentInputModel
    {
        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public string ClientLogoUrl { get; set; }
        public string RedirectUrl { get; set; }
        public bool AllowRememberConsent { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }

        public IEnumerable<ScopeViewModel> IdentityScopes { get; set; }
        public IEnumerable<ScopeViewModel> ResourceScopes { get; set; }
    }
}
