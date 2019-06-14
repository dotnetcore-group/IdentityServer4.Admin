using IdentityServer4.Admin.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.User
{
    public class CreateUserCommandValidation : UserValidation<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            ValidateUserName();
            ValidateEmail();
            ValidatePassword();
            ValidateNickname();
        }
    }
}
