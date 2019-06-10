using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Models.User
{
    public class ProfileViewModel : ProfileInputModel
    {
        public string Avatar { get; set; }
    }
}
