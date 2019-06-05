using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Models
{
    public class ExternalProvider
    {
        public string DisplayName { get; set; }
        public string AuthenticationScheme { get; set; }

        public string NormalizedName => DisplayName?.ToLower();
        public string Fontawesome => _icons[NormalizedName] ?? "";


        private Dictionary<string, string> _icons = new Dictionary<string, string>
        {
            {"google","fa-google-plus" },
            {"facebook","fa-facebook" },
            {"twitter","fa-twitter" },
            {"microsoft","fa-windows" },
        };
    }
}
