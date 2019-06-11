using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.User
{
    public class PagingUserViewModel
    {
        public string Email { get; set; }
        public string Uid { get; set; }
        public string UserName { get; set; }
        public string Nickname { get; set; }
    }
}
