using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Application.ViewModels
{
    public class StartupViewModel
    {
        public StartupViewModel()
        {
            DefaultUser = new DefaultUser();
        }

        public DefaultUser DefaultUser { get; set; }
    }

    public class DefaultUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }
    }
}
