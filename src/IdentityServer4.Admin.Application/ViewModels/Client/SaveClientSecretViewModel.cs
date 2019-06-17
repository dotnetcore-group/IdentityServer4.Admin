using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.Client
{
    public class SaveClientSecretViewModel
    {
        [JsonIgnore]
        public string ClientId { get; set; }
        [Required]
        public string Value { get; set; }
        public int HashType { get; set; } = Domain.Models.HashType.Sha256.Id;
        public DateTime? Expiration { get; set; }
        public string Description { get; set; }
    }
}
