using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.ApiResource
{
    public class RemoveApiResourceViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
