using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.ApiResource
{
    public class RemoveApiScopeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ApiResourceName { get; set; }
    }
}
