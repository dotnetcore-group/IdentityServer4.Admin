using IdentityServer4.Admin.Domain.Validations.User;
using System;

namespace IdentityServer4.Admin.Domain.Commands.User
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(string username, string email, string nickname, string password, string confirmPassword, bool emailConfirmed)
        {
            UserName = username;
            Email = email;
            Nickname = nickname;
            Password = password;
            ConfirmPassword = confirmPassword;
            EmailConfirmed = emailConfirmed;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
