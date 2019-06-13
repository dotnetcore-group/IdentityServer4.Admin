using IdentityServer4.Admin.Domain.Validations.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client
{
    public class RemoveClientCommand : ClientCommand
    {
        public RemoveClientCommand(string clientId)
        {
            Client = new IdentityServer4.Models.Client { ClientId = clientId };
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
