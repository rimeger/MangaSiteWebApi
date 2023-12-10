using AutoMapper;
using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using Manga.Application.Abstractions;
using Manga.Application.Exceptions;
using Manga.Application.Features.UserFeatures.Commands.Register;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

using Xunit;

namespace Manga.Application.UnitTests.Features.UserFeartures.Commands
{
    public class RegisterHandlerTests
    {
        private readonly IUserService _userServiceMock;
        private readonly IValidator<RegisterCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProviderMock;
        private readonly IPasswordHasher _passwordHasherMock;
        public RegisterHandlerTests()
        {
            _userServiceMock = Substitute.For<IUserService>();
            _validator = new RegisterValidator();
            _mapper = Substitute.For<IMapper>();
            _jwtProviderMock = Substitute.For<IJwtProvider>();
            _passwordHasherMock = Substitute.For<IPasswordHasher>();
        }

        [Fact]
        public async Task Handle_Should_ReturnToken()
        {
            //Arrange
            var username = "username";
            var email = "test@test.com";
            var password = "password";
            var command = new RegisterCommand
            {
                UserName = username,
                Email = email,
                Password = password
            };
            var handler = new RegisterHandler(_userServiceMock, _validator, _mapper, _jwtProviderMock, _passwordHasherMock);
            var user = new User
            {
                UserName = username,
                Email = email,
                Password = password
            };
            string token = "token";
            string hashedPassword = "hash";
            _userServiceMock.GetByUserName(username).ReturnsNull();
            _mapper.Map<User>(Arg.Any<RegisterCommand>()).Returns(user);
            _passwordHasherMock.Hash(command.Password).Returns(hashedPassword);
            _jwtProviderMock.Generate(user).Returns(token);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            await _userServiceMock.Received(1).GetByUserName(username);
            await _userServiceMock.Received(1).CreateAsync(user);
            _jwtProviderMock.Received(1).Generate(user);
            _passwordHasherMock.Received(1).Hash(command.Password);

            result.Should().BeOfType<string>();
            result.Should().BeEquivalentTo(token);
        }

        [Fact]
        public void Handle_Should_ThrowValidationError()
        {
            //Arrange
            var username = "ab";
            var email = "test";
            var password = "123";
            var command = new RegisterCommand
            {
                UserName = username,
                Email = email,
                Password = password
            };
            var handler = new RegisterHandler(_userServiceMock, _validator, _mapper, _jwtProviderMock, _passwordHasherMock);

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.UserName);
            result.ShouldHaveValidationErrorFor(c => c.Email);
            result.ShouldHaveValidationErrorFor(c => c.Password);
        }

        [Fact]
        public async Task Handle_Should_ThrowError_WhenUsernameIsAlreadyTaken()
        {
            //Arrange
            var username = "username";
            var email = "test@test.com";
            var password = "password";
            var command = new RegisterCommand
            {
                UserName = username,
                Email = email,
                Password = password
            };
            var handler = new RegisterHandler(_userServiceMock, _validator, _mapper, _jwtProviderMock, _passwordHasherMock);
            var user = new User
            {
                UserName = username,
                Email = email,
                Password = password
            };
            _userServiceMock.GetByUserName(username).Returns(user);

            // Act and Assert
            Func<Task> act = async () => await handler.Handle(command, default);

            await act.Should().ThrowAsync<InvalidCredentials>()
                .WithMessage("Username is already taken");

            await _userServiceMock.Received(1).GetByUserName(username);
        }
    }
}
