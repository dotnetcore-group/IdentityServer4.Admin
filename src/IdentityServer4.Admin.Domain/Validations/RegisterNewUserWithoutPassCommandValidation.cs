using IdentityServer4.Admin.Domain.Commands;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class RegisterNewUserWithoutPassCommandValidation : UserValidation<RegisterNewUserWithoutPassCommand>
    {
        public RegisterNewUserWithoutPassCommandValidation(bool emailValidation = true)
        {
            ValidateNickname();
            ValidateUsername();
            if (emailValidation)
            {
                ValidateEmail();
            }
            ValidateProvider();
            ValidateProviderId();
        }
    }
}
