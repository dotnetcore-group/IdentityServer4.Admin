using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.Client
{
    public class UpdateClientViewModel : Models.Client
    {
        [Required]
        public string OriginalClinetId { get; set; }
    }
}
