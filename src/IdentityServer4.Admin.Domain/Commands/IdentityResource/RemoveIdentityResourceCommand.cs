using IdentityServer4.Admin.Domain.Validations.IdentityResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.IdentityResource
{
    public class RemoveIdentityResourceCommand : IdentityResourceCommand
    {
        public RemoveIdentityResourceCommand(string name)
        {
            IdentityResource = new IdentityServer4.Models.IdentityResource { Name = name };
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveIdentityResourceCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
