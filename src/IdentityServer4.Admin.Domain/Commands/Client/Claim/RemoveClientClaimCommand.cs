using IdentityServer4.Admin.Domain.Validations.Client.Claim;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client.Claim
{
    public class RemoveClientClaimCommand : ClientClaimCommand
    {
        public RemoveClientClaimCommand(string clientId, int id)
        {
            ClientId = clientId;
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientClaimCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
