using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.ApiResource
{
    public class SetApiSecretViewModel
    {
        public string Description { get; set; }
        [Required]
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public HashType? HashType { get; set; } = ViewModels.HashType.Sha256;
        public string Type { get; set; }
        [Required]
        public string ApiResourceName { get; set; }
    }
}
