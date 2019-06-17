using IdentityServer4.Admin.Domain.Validations.IdentityResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.IdentityResource
{
    public class CreateIdentityResourceCommand : IdentityResourceCommand
    {
        public CreateIdentityResourceCommand(IdentityServer4.Models.IdentityResource resource)
        {
            IdentityResource = resource;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateIdentityResourceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
