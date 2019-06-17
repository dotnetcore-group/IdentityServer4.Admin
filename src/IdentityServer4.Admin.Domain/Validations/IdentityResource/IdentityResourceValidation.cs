using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.IdentityResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.IdentityResource
{
    public abstract class IdentityResourceValidation<T> : AbstractValidator<IdentityResourceCommand> where T : IdentityResourceCommand
    {
        protected void ValidateName()
        {
            RuleFor(r => r.IdentityResource.Name).NotEmpty().WithMessage("ResourceName cannot be null or empty");
        }
    }
}
