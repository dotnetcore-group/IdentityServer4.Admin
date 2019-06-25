using IdentityServer4.Admin.Domain.Validations.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client
{
    public class UpdateClientCommand : ClientCommand
    {
        public string OriginalClinetId { get; set; }
        public UpdateClientCommand(IdentityServer4.Models.Client client, string originalClinetId)
        {
            Client = client;
            OriginalClinetId = originalClinetId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
