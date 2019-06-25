using IdentityServer4.Admin.Domain.Validations.Client.Property;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client.Property
{
    public class SaveClientPropertyCommand : ClientPropertyCommand
    {
        public SaveClientPropertyCommand(string clientId, string key, string value)
        {
            ClientId = clientId;
            Key = key;
            Value = value;
        }

        public override bool IsValid()
        {
            ValidationResult = new SaveClientPropertyCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
