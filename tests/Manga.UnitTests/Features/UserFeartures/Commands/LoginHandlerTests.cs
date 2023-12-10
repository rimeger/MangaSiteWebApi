using AutoMapper;
using FluentAssertions;
using Manga.Application.Abstractions;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Features.UserFeatures.Commands.Login;
using Manga.Application.Features.UserFeatures.Queries.GetBookmarks;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Manga.Application.UnitTests.Features.UserFeartures.Commands
{
    public class LoginHandlerTests
    {
        private readonly IUserService _userServiceMock;
        private readonly IJwtProvider _jwtProviderMock;
        private readonly IPasswordHasher _passwordHasherMock;
        public LoginHandlerTests()
        {
            _userServiceMock = Substitute.For<IUserService>();
            _jwtProviderMock = Substitute.For<IJwtProvider>();
            _passwordHasherMock = Substitute.For<IPasswordHasher>();
        }

        [Fact]
        public async Task Handle_Should_ReturnToken()
        {
            //Arrange
            var username = "username";
            var password = "password";
            var command = new LoginCommand(username, password);
            var handler = new LoginHandler(_userServiceMock, _jwtProviderMock, _passwordHasherMock);
            var user = new User
            {
                UserName = username,
                Password = password
            };
            string token = "token";
            _userServiceMock.GetByUserName(username).Returns(user);
            _passwordHasherMock.Verify(command.password, user.Password).Returns(true);
            _jwtProviderMock.Generate(user).Returns(token);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            await _userServiceMock.Received(1).GetByUserName(username);
            _jwtProviderMock.Received(1).Generate(user);
            _passwordHasherMock.Received(1).Verify(command.password, user.Password);

            result.Should().BeOfType<string>();
            result.Should().BeEquivalentTo(token);
        }

        [Fact]
        public async Task Handle_Should_ThrowError_WhenWrongPassword()
        {
            //Arrange
            var username = "username";
            var password = "password";
            var command = new LoginCommand(username, password);
            var handler = new LoginHandler(_userServiceMock, _jwtProviderMock, _passwordHasherMock);
            var user = new User
            {
                UserName = username,
                Password = password
            };
            string token = "token";
            _userServiceMock.GetByUserName(username).Returns(user);
            _passwordHasherMock.Verify(command.password, user.Password).Returns(false);

            // Act and Assert
            Func<Task> act = async () => await handler.Handle(command, default);

            await act.Should().ThrowAsync<InvalidCredentials>()
                .WithMessage("Bad credentials");

            await _userServiceMock.Received(1).GetByUserName(username);
            _passwordHasherMock.Received(1).Verify(command.password, user.Password);
        }

        [Fact]
        public async Task Handle_Should_ThrowError_WhenWrongUsername()
        {
            //Arrange
            var username = "username";
            var password = "password";
            var command = new LoginCommand(username, password);
            var handler = new LoginHandler(_userServiceMock, _jwtProviderMock, _passwordHasherMock);
            var user = new User
            {
                UserName = username,
                Password = password
            };
            _userServiceMock.GetByUserName(username).ReturnsNull();

            // Act and Assert
            Func<Task> act = async () => await handler.Handle(command, default);

            await act.Should().ThrowAsync<InvalidCredentials>()
                .WithMessage("Bad credentials");

            await _userServiceMock.Received(1).GetByUserName(username);
        }
    }
}
