using IdentityServer4.Admin.Domain.Commands.Client.Property;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client.Property
{
    public class SaveClientPropertyCommandValidation : ClientPropertyCommandValidation<SaveClientPropertyCommand>
    {
        public SaveClientPropertyCommandValidation()
        {
            ValidateClientId();
            ValidateKey();
            ValidateValue();
        }
    }
}
