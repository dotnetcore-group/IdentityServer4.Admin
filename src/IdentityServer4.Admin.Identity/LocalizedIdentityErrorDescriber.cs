using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityServer4.Admin.Identity
{
    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<LocalizedIdentityErrorDescriber> _localizer;
        public LocalizedIdentityErrorDescriber(IStringLocalizer<LocalizedIdentityErrorDescriber> localizer)
        {
            _localizer = localizer;
        }

        public override IdentityError ConcurrencyFailure()
            => new IdentityError { Code = nameof(ConcurrencyFailure), Description = _localizer[nameof(ConcurrencyFailure)] };

        public override IdentityError DefaultError()
            => new IdentityError { Code = nameof(DefaultError), Description = _localizer[nameof(DefaultError)] };

        public override IdentityError DuplicateEmail(string email)
            => new IdentityError { Code = nameof(DuplicateEmail), Description = _localizer[nameof(DuplicateEmail), email] };

        public override IdentityError DuplicateRoleName(string role)
            => new IdentityError { Code = nameof(DuplicateRoleName), Description = _localizer[nameof(DuplicateRoleName), role] };

        public override IdentityError DuplicateUserName(string userName)
            => new IdentityError { Code = nameof(DuplicateUserName), Description = _localizer[nameof(DuplicateUserName), userName] };

        public override IdentityError InvalidEmail(string email)
            => new IdentityError { Code = nameof(InvalidEmail), Description = _localizer[nameof(InvalidEmail), email] };

        public override IdentityError InvalidRoleName(string role)
            => new IdentityError { Code = nameof(InvalidRoleName), Description = _localizer[nameof(InvalidRoleName), role] };

        public override IdentityError InvalidToken()
            => new IdentityError { Code = nameof(InvalidToken), Description = _localizer[nameof(InvalidToken)] };

        public override IdentityError InvalidUserName(string userName)
            => new IdentityError { Code = nameof(InvalidUserName), Description = _localizer[nameof(InvalidUserName), userName] };

        public override IdentityError LoginAlreadyAssociated()
            => new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = _localizer[nameof(LoginAlreadyAssociated)] };

        public override IdentityError PasswordMismatch()
            => new IdentityError { Code = nameof(PasswordMismatch), Description = _localizer[nameof(PasswordMismatch)] };

        public override IdentityError PasswordRequiresDigit()
            => new IdentityError { Code = nameof(PasswordRequiresDigit), Description = _localizer[nameof(PasswordRequiresDigit)] };

        public override IdentityError PasswordRequiresLower()
            => new IdentityError { Code = nameof(PasswordRequiresLower), Description = _localizer[nameof(PasswordRequiresLower)] };

        public override IdentityError PasswordRequiresNonAlphanumeric()
            => new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = _localizer[nameof(PasswordRequiresNonAlphanumeric)] };

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
            => new IdentityError { Code = nameof(PasswordRequiresUniqueChars), Description = _localizer[nameof(PasswordRequiresUniqueChars)] };

        public override IdentityError PasswordRequiresUpper()
            => new IdentityError { Code = nameof(PasswordRequiresUpper), Description = _localizer[nameof(PasswordRequiresUpper)] };

        public override IdentityError PasswordTooShort(int length)
            => new IdentityError { Code = nameof(PasswordTooShort), Description = _localizer[nameof(PasswordTooShort), length] };

        public override IdentityError RecoveryCodeRedemptionFailed()
            => new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = _localizer[nameof(RecoveryCodeRedemptionFailed)] };

        public override IdentityError UserAlreadyHasPassword()
            => new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = _localizer[nameof(UserAlreadyHasPassword)] };

        public override IdentityError UserAlreadyInRole(string role)
            => new IdentityError { Code = nameof(UserAlreadyInRole), Description = _localizer[nameof(UserAlreadyInRole)] };

        public override IdentityError UserLockoutNotEnabled()
            => new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = _localizer[nameof(UserLockoutNotEnabled)] };

        public override IdentityError UserNotInRole(string role)
            => new IdentityError { Code = nameof(UserNotInRole), Description = _localizer[nameof(UserNotInRole)] };
    }
}
