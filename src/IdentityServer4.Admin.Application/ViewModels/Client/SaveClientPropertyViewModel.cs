using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.Client
{
    public class SaveClientPropertyViewModel
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }

        [JsonIgnore]
        public string ClientId { get; set; }
    }
}
