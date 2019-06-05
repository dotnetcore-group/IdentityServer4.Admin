using IdentityServer4.Admin.Domain.Commands;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class RegisterNewUserWithoutPassCommandValidation : UserValidation<RegisterNewUserWithoutPassCommand>
    {
        public RegisterNewUserWithoutPassCommandValidation()
        {
            ValidateName();
            ValidateUsername();
            ValidateEmail();
            ValidateProvider();
            ValidateProviderId();
        }
    }
}
