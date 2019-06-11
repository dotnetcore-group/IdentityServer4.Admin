using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.Client
{
    public class ClientViewModel
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public bool Enabled { get; set; }
        public string LogoUri { get; set; }
    }
}
