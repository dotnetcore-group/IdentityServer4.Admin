using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.SSO.Models.Account
{
    public class RegisterInputModel
    {
        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string Nickname { get; set; }

        public string ReturnUrl { get; set; }
    }
}
