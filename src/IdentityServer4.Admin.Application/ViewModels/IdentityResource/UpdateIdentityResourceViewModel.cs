using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Application.ViewModels.IdentityResource
{
    public class UpdateIdentityResourceViewModel : Models.IdentityResource
    {
        public string OldName { get; set; }
    }
}
