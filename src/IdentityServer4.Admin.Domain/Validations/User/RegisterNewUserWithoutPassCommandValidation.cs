using IdentityServer4.Admin.Domain.Commands;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class RegisterNewUserWithoutPassCommandValidation : UserValidation<RegisterNewUserWithoutPassCommand>
    {
        public RegisterNewUserWithoutPassCommandValidation(bool emailValidation = true)
        {
            ValidateNickname();
            ValidateUserName();
            if (emailValidation)
            {
                ValidateEmail();
            }
            ValidateProvider();
            ValidateProviderId();
        }
    }
}
