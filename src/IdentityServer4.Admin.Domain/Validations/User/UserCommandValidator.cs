using FluentValidation;
using IdentityServer4.Admin.Domain.Commands;
using System;

namespace IdentityServer4.Admin.Domain.Validations
{
    public abstract class UserCommandValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateNickname()
        {
            RuleFor(c => c.Nickname)
                .NotEmpty().WithMessage("Please ensure you have entered the Nickname")
                .Length(2, 150).WithMessage("The Nickname must have between 2 and 150 characters");
        }


        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateUserName()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Please ensure you have entered the Username")
                .Length(2, 50).WithMessage("The Username must have between 2 and 50 characters");
        }

        protected void ValidatePassword()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please ensure you have entered the password")
                .Equal(c => c.ConfirmPassword).WithMessage("Password and Confirm password must be equal")
                .MinimumLength(8).WithMessage("Password minimun length must be 8 characters");
        }

        protected void ValidateProvider()
        {
            RuleFor(c => c.Provider)
                .NotEmpty();
        }

        protected void ValidateProviderId()
        {
            RuleFor(c => c.ProviderId)
                .NotEmpty();
        }

        protected void ValidateToken()
        {
            RuleFor(c => c.Token)
                .NotEmpty();
        }
    }
}
