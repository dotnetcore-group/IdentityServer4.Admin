using IdentityServer4.Admin.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.Client
{
    public class CreateClientViewModel
    {
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ClientType ClientType => ClientType.From(ClientTypeId);
        public int ClientTypeId { get; set; }
    }
}
