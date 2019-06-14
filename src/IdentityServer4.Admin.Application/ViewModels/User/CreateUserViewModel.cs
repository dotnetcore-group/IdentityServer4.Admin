using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.User
{
    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Nickname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool EmailConfirmed { get; set; } = true;
    }
}
