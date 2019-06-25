using IdentityServer4.Admin.Domain.Validations.Client.Claim;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client.Claim
{
    public class SaveClientClaimCommand : ClientClaimCommand
    {
        public SaveClientClaimCommand(string clientId, string type, string value)
        {
            ClientId = clientId;
            Type = type;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new SaveClientClaimCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
