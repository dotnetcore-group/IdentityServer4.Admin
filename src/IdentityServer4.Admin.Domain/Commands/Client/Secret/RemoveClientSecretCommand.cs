using IdentityServer4.Admin.Domain.Validations.Client.Secret;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client.Secret
{
    public class RemoveClientSecretCommand : ClientSecretCommand
    {
        public RemoveClientSecretCommand(string clientId, int id)
        {
            ClientId = clientId;
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientSecretCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
