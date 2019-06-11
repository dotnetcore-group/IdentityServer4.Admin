using IdentityServer4.Admin.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.ApiResource
{
    public class SetApiScopeCommand : ApiScopeCommand
    {
        public SetApiScopeCommand(string apiResourceName, string name, string displayName, string description, bool required, bool emphasize, bool showInDiscoveryDocument, IEnumerable<string> userClaims)
        {
            ApiResourceName = apiResourceName;
            Name = name;
            DisplayName = displayName;
            Description = description;
            Required = required;
            Emphasize = emphasize;
            ShowInDiscoveryDocument = showInDiscoveryDocument;
            UserClaims = userClaims;
        }

        public override bool IsValid()
        {
            ValidationResult = new SetApiScopeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
