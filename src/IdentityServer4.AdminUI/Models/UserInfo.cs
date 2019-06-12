using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.AdminUI.Models
{
    public class UserInfo
    {
        public string Nickname { get; set; }
        public string UserName { get; set; }
        public string Gravatar { get; set; }
        public string Email { get; set; }
    }
}
