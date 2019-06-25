using IdentityServer4.Admin.Domain.Validations.ApiResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.ApiResource
{
    public class RemoveApiResourceCommand : ApiResourceCommand
    {
        public RemoveApiResourceCommand(string name)
        {
            ApiResource = new IdentityServer4.Models.ApiResource { Name = name };
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveApiResourceCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
