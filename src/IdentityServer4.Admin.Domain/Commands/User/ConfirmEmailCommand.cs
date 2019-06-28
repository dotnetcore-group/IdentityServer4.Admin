using IdentityServer4.Admin.Domain.Validations.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.User
{
    public class ConfirmEmailCommand : UserCommand
    {
        public ConfirmEmailCommand(string email, string token)
        {
            Token = token;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new ConfirmEmailCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
