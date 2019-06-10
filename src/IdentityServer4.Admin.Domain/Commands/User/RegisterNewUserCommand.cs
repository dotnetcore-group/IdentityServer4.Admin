using IdentityServer4.Admin.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.User
{
    public class RegisterNewUserCommand : UserCommand
    {
        public RegisterNewUserCommand(string email, string password, string confirmPassword)
        {
            Email = email;
            Username = email;
            Nickname = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
