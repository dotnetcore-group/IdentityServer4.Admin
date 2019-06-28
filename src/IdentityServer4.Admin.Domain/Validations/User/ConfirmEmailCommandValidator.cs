using IdentityServer4.Admin.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.User
{
    public class ConfirmEmailCommandValidator : UserCommandValidation<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            ValidateEmail();
            ValidateToken();
        }
    }
}
