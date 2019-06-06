using IdentityServer4.Admin.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands
{
    public class RegisterNewUserWithoutPassCommand : UserCommand
    {
        public RegisterNewUserWithoutPassCommand(string username, string email, string nickname, string provider, string providerId)
        {
            Provider = provider;
            ProviderId = providerId;
            Username = username;
            Email = email;
            Nickname = nickname;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserWithoutPassCommandValidation(string.IsNullOrEmpty(Email) == false)
                .Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
