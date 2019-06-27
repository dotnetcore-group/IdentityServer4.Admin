using IdentityServer4.Admin.Domain.Commands.ApiResource;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.ApiResource
{
    public class RemoveApiResourceCommandValidator : ApiResourceCommandValidator<RemoveApiResourceCommand>
    {
        public RemoveApiResourceCommandValidator()
        {
            ValidateName();
        }
    }
}
