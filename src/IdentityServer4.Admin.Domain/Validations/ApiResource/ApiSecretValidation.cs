using FluentValidation;
using IdentityServer4.Admin.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations
{
    public abstract class ApiSecretValidation<T> : AbstractValidator<T> where T : ApiSecretCommand
    {

        protected void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid secret");
        }
        protected void ValidateApiResourceName()
        {
            RuleFor(c => c.ApiResourceName).NotEmpty().WithMessage("ClientId must be set");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("Secret must be set");
        }
        protected void ValidateType()
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Please ensure you have selected Type");
        }

        protected void ValidateHashType()
        {
            RuleFor(c => c.HashType).InclusiveBetween(0, 1).WithMessage("Please set hash type");
        }
    }
}
