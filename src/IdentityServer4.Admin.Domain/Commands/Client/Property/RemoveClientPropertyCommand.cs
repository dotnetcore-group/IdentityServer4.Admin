using IdentityServer4.Admin.Domain.Validations.Client.Property;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client
{
    public class RemoveClientPropertyCommand : ClientPropertyCommand
    {
        public RemoveClientPropertyCommand(string clientId, int id)
        {
            ClientId = clientId;
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientPropertyCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
