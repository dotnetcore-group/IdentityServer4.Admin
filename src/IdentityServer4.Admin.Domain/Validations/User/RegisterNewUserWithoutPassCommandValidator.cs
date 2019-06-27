using IdentityServer4.Admin.Domain.Commands;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class RegisterNewUserWithoutPassCommandValidator : UserCommandValidation<RegisterNewUserWithoutPassCommand>
    {
        public RegisterNewUserWithoutPassCommandValidator(bool emailValidation = true)
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
