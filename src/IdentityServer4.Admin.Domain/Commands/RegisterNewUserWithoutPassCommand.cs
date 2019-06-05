using IdentityServer4.Admin.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands
{
    public class RegisterNewUserWithoutPassCommand : UserCommand
    {
        public RegisterNewUserWithoutPassCommand(string username, string email, string name, string provider, string providerId)
        {
            Provider = provider;
            ProviderId = providerId;
            Username = username;
            Email = email;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserWithoutPassCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
