using IdentityServer4.Admin.Domain.Commands.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Property
{
    public class RemoveClientPropertyCommandValidator : ClientPropertyCommandValidator<RemoveClientPropertyCommand>
    {
        public RemoveClientPropertyCommandValidator()
        {
            ValidateId();
            ValidateClientId();
        }
    }
}
