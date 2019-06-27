using IdentityServer4.Admin.Domain.Validations.IdentityResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.IdentityResource
{
    public class UpdateIdentityResourceCommand : IdentityResourceCommand
    {
        public UpdateIdentityResourceCommand(string oldNam, IdentityServer4.Models.IdentityResource resource)
        {
            IdentityResource = resource;
            OldIdentityResourceName = oldNam;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateIdentityResourceCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
