using IdentityModel;
using IdentityServer4.Admin.Domain.Models;
using IdentityServer4.Admin.Domain.Validations.Client.Secret;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Commands.Client.Secret
{
    public class SaveClientSecretCommand : ClientSecretCommand
    {
        public SaveClientSecretCommand(string clientId, string value, string description, HashType type, DateTime? expiration)
        {
            ClientId = clientId;
            Value = value;
            HashType = type.Id;
            Description = description;
            Expiration = expiration;
            Type = type.Name;
        }

        public override bool IsValid()
        {
            ValidationResult = new SaveClientSecretCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public string GetHashValue()
        {
            switch (HashType)
            {
                case 0:
                    return Value.ToSha256();
                case 1:
                    return Value.ToSha512();
                default:
                    throw new ArgumentException(nameof(HashType));
            }
        }
    }
}
