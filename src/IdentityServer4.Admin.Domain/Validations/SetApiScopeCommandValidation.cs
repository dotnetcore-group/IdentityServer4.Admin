using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.ApiResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class SetApiScopeCommandValidation : ApiScopeValidation<SetApiScopeCommand>
    {
        public SetApiScopeCommandValidation()
        {
            ValidateApiResourceName();
        }
    }
}
