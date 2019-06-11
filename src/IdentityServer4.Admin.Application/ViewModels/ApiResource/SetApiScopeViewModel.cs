using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.ApiResource
{
    public class SetApiScopeViewModel
    {
        [Required]
        public string ApiResourceName { get; set; }
        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; } = false;
        public bool Emphasize { get; set; } = false;
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public IEnumerable<string> UserClaims { get; set; } = new HashSet<string>();
    }
}
