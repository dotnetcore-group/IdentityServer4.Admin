using IdentityServer4.Admin.Domain.Commands.Client.Secret;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Secret
{
    public class SaveClientSecretCommandValidator : ClientSecretCommandValidator<SaveClientSecretCommand>
    {
        public SaveClientSecretCommandValidator()
        {
            ValidateClientId();
            ValidateValue();
            ValidateHashType();
        }
    }
}
