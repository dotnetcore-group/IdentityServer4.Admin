﻿using IdentityServer4.Admin.Domain.Commands.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client
{
    public class CreateClientCommandValidation : ClientValidation<CreateClientCommand>
    {
        public CreateClientCommandValidation()
        {
            ValidateClientId();
            ValidateClientName();
        }
    }
}
