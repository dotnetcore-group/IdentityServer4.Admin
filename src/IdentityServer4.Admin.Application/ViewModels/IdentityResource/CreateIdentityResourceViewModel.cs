using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.IdentityResource
{
    public class CreateIdentityResourceViewModel
    {
        public bool Required { get; set; } = true;
        public bool Emphasize { get; set; } = false;
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public bool Enabled { get; set; } = true;

        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();
    }
}
