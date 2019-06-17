using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.Client.Secret;
using IdentityServer4.Admin.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Secret
{
    public abstract class ClientSecretCommandValidation<T> : AbstractValidator<ClientSecretCommand> where T : ClientSecretCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid SecretId");
        }

        protected void ValidateClientId()
        {
            RuleFor(c => c.ClientId).NotEmpty().WithMessage("ClientId cannot be null or empty");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("Value must be set");
        }

        protected void ValidateHashType()
        {
            RuleFor(c => c.HashType).InclusiveBetween(HashType.Sha256.Id, HashType.Sha512.Id).WithMessage("Please set hash type");
        }
    }
}
