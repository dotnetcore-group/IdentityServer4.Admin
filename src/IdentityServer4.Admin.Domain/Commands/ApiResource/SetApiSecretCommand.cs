using IdentityServer4.Admin.Domain.Validations;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.ApiResource
{
    public class SetApiSecretCommand : ApiSecretCommand
    {
        public SetApiSecretCommand(string apiResourceName, string description, string value, string type, DateTime? expiration, int hashType)
        {
            ApiResourceName = apiResourceName;
            Description = description;
            Value = value;
            Type = type;
            Expiration = expiration;
            HashType = hashType;
        }

        public override bool IsValid()
        {
            ValidationResult = new SetApiSecretCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        public string GetHashValue()
        {
            if (HashType == 0)
            {
                return Value.Sha256();
            }
            else if (HashType == 1)
            {
                return Value.Sha512();
            }
            else
            {
                throw new ArgumentException(nameof(HashType));
            }
        }
    }
}
