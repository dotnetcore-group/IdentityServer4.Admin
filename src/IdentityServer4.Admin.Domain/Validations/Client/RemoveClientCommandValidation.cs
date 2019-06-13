using IdentityServer4.Admin.Domain.Commands.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client
{
    public class RemoveClientCommandValidation : ClientValidation<RemoveClientCommand>
    {
        public RemoveClientCommandValidation()
        {
            ValidateClientId();
        }
    }
}
