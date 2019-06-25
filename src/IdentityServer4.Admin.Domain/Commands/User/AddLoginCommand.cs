using IdentityServer4.Admin.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.User
{
    public class AddLoginCommand : UserCommand
    {
        public AddLoginCommand(string username, string provider, string providerId)
        {
            UserName = username;
            Provider = provider;
            ProviderId = providerId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddLoginCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
