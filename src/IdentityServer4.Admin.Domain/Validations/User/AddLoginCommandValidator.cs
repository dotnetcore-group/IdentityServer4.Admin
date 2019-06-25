using IdentityServer4.Admin.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class AddLoginCommandValidator: UserCommandValidation<AddLoginCommand>
    {
        public AddLoginCommandValidator()
        {
            ValidateUserName();
            ValidateProvider();
            ValidateProviderId();
        }
    }
}
