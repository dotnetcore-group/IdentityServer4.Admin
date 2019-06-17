using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.Client
{
    public class SaveClientClaimViewModel
    {
        [JsonIgnore]
        public string ClientId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
