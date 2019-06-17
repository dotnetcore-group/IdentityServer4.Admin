using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Property
{
    public abstract class ClientPropertyCommandValidation<T>
        : AbstractValidator<ClientPropertyCommand> where T : ClientPropertyCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid property id");
        }

        protected void ValidateClientId()
        {
            RuleFor(c => c.ClientId).NotEmpty().WithMessage("ClientId cannot be null or empty");
        }

        protected void ValidateKey()
        {
            RuleFor(c => c.Key).NotEmpty().WithMessage("Key must be set");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("Value must be set");
        }
    }
}
