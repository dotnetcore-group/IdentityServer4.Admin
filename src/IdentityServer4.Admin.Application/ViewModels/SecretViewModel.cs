using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels
{
    public class SecretViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public HashType HashType { get; set; }
        public string Type { get; set; }
    }
    public enum HashType
    {
        Sha256,
        Sha512
    }
}
