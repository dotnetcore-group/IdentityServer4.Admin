using IdentityServer4.Admin.Domain.Commands.Client.Secret;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Secret
{
    public class RemoveClientSecretCommandValidator : ClientSecretCommandValidator<RemoveClientSecretCommand>
    {
        public RemoveClientSecretCommandValidator()
        {
            ValidateId();
            ValidateClientId();
        }
    }
}
