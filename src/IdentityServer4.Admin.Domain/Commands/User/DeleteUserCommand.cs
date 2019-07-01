using IdentityServer4.Admin.Domain.Validations.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.User
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
