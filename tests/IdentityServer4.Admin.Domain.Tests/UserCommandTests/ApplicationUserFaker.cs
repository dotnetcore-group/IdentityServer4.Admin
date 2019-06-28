using Bogus;
using IdentityServer4.Admin.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Tests.UserCommandTests
{
    public static class ApplicationUserFaker
    {
        public static Faker<ApplicationUser> GenerateUser() =>
            new Faker<ApplicationUser>()
                .RuleFor(u => u.Id, f => f.Random.Uuid())
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.EmailConfirmed, f => f.Random.Bool())
                .RuleFor(u => u.PasswordHash, f => f.Lorem.Word())
                .RuleFor(u => u.SecurityStamp, f => f.Lorem.Word())
                .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
                .RuleFor(u => u.PhoneNumberConfirmed, f => f.Random.Bool())
                .RuleFor(u => u.TwoFactorEnabled, f => f.Random.Bool())
                .RuleFor(u => u.LockoutEnabled, f => f.Random.Bool())
                .RuleFor(u => u.AccessFailedCount, f => f.Random.Int())
                .RuleFor(u => u.UserName, f => f.Person.UserName)
                .RuleFor(u => u.Avatar, f => f.Image.LoremFlickrUrl())
                .RuleFor(u => u.Nickname, f => f.Person.FullName);
    }
}
