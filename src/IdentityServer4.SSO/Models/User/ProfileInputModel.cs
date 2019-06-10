using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Models.User
{
    public class ProfileInputModel
    {
        public string Nickname { get; set; }
        public string UserName { get; set; }
    }
}
