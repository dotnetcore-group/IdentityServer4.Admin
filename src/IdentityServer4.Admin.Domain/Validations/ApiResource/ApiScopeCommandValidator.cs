using FluentValidation;
using IdentityServer4.Admin.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations
{
    public abstract class ApiScopeCommandValidator<T> : AbstractValidator<T> where T : ApiScopeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid scope");
        }
        protected void ValidateApiResourceName()
        {
            RuleFor(c => c.ApiResourceName).NotEmpty().WithMessage("ApiResourceName must be set");
        }
    }
}
