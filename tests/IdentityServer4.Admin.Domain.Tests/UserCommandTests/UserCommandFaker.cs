using Bogus;
using IdentityServer4.Admin.Domain.Commands.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Tests.UserCommandTests
{
    public static class UserCommandFaker
    {
        public static Faker<CreateUserCommand> GenerateCreateUserCommand(string comfirmPassword = null)
        {
            var password = new Faker().Internet.Password();
            return new Faker<CreateUserCommand>()
            .CustomInstantiator(f => new CreateUserCommand(
                f.Person.UserName,
                f.Person.Email,
                f.Person.FullName,
                password,
                comfirmPassword ?? password,
                f.Random.Bool())
            );
        }

    }
}
