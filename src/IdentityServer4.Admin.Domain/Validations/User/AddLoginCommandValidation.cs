using IdentityServer4.Admin.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class AddLoginCommandValidation: UserValidation<AddLoginCommand>
    {
        public AddLoginCommandValidation()
        {
            ValidateUserName();
            ValidateProvider();
            ValidateProviderId();
        }
    }
}
