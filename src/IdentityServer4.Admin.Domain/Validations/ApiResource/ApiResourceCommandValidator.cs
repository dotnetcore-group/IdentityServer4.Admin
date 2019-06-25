using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.ApiResource
{
    public abstract class ApiResourceCommandValidator<T> : AbstractValidator<T> where T : ApiResourceCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.ApiResource.Name).NotEmpty().WithMessage("Invalid resource name");
        }
    }
}
