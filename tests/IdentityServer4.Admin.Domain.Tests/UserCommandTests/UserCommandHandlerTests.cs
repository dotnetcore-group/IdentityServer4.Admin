using Bogus;
using IdentityServer4.Admin.BuildingBlock.Drawing;
using IdentityServer4.Admin.Domain.CommandHandlers;
using IdentityServer4.Admin.Domain.Commands.User;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Admin.Domain.Interfaces;
using IdentityServer4.Admin.Identity.Entities;
using IdGen;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace IdentityServer4.Admin.Domain.Tests.UserCommandTests
{
    public class UserCommandHandlerTests
    {
        private readonly Faker _faker;
        private readonly UserCommandHandler _commandHandler;
        private readonly CancellationTokenSource _tokenSource;
        private readonly Mock<IUserManager> _userManager;
        private readonly Mock<IIdGenerator<long>> _idGenerator;
        public UserCommandHandlerTests()
        {
            _faker = new Faker();
            _tokenSource = new CancellationTokenSource();
            var uow = new Mock<IUnitOfWork>();
            var bus = new Mock<IMediatorHandler>();
            var notifications = new Mock<DomainNotificationHandler>();
            _userManager = new Mock<IUserManager>();
            _idGenerator = new Mock<IIdGenerator<long>>();
            _commandHandler = new UserCommandHandler(uow.Object, bus.Object, notifications.Object, _userManager.Object, _idGenerator.Object);
        }

        [Fact]
        public async Task CannotCreateNewUserIfEmailAlreadyExisted()
        {
            var command = UserCommandFaker.GenerateCreateUserCommand().Generate();

            _userManager.Setup(u => u.FindByEmailAsync(command.Email))
                .ReturnsAsync(ApplicationUserFaker.GenerateUser().Generate());


            var result = await _commandHandler.Handle(command, _tokenSource.Token);


            Assert.False(result);
        }

        [Fact]
        public async Task CannotCreateNewUserIfUserNameAlreadyExisted()
        {
            var command = UserCommandFaker.GenerateCreateUserCommand().Generate();

            _userManager.Setup(u => u.FindByEmailAsync(command.Email))
                .ReturnsAsync(value: null);
            _userManager.Setup(u => u.FindByNameAsync(command.UserName))
                .ReturnsAsync(ApplicationUserFaker.GenerateUser().Generate());

            var result = await _commandHandler.Handle(command, _tokenSource.Token);


            Assert.False(result);
        }
    }
}
