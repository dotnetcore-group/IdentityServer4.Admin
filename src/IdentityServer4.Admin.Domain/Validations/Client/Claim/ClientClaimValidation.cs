using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.Client.Claim;

namespace IdentityServer4.Admin.Domain.Validations.Client.Claim
{
    public abstract class ClientClaimValidation<T> : AbstractValidator<ClientClaimCommand> where T : ClientClaimCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Invalid ClaimId");
        }
        protected void ValidateClientId()
        {
            RuleFor(c => c.ClientId).NotEmpty().WithMessage("ClientId cannot be null or empty");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value).NotEmpty().WithMessage("Secret must be set");
        }
        protected void ValidateType()
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Please ensure you have entered key");
        }
    }
}