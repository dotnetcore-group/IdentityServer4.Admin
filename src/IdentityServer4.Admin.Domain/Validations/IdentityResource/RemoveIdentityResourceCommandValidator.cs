using IdentityServer4.Admin.Domain.Commands.IdentityResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.IdentityResource
{
    public class RemoveIdentityResourceCommandValidator : IdentityResourceCommandValidation<RemoveIdentityResourceCommand>
    {
        public RemoveIdentityResourceCommandValidator()
        {
            ValidateName();
        }
    }
}
