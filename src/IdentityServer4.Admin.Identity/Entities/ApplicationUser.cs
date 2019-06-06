using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Identity.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Nickname { get; set; }
        public string Avatar { get; set; }
        public long Uid { get; set; }
    }
}
