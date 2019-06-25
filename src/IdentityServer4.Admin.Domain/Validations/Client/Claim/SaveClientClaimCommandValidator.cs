using IdentityServer4.Admin.Domain.Commands.Client.Claim;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Claim
{
    public class SaveClientClaimCommandValidator : ClientClaimCommandValidator<SaveClientClaimCommand>
    {
        public SaveClientClaimCommandValidator()
        {
            ValidateClientId();
            ValidateType();
            ValidateValue();
        }
    }
}
