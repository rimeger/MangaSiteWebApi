using Manga.Application.Abstractions;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.UserFeatures.Commands.Login
{
    public record LoginCommand(string username, string password) : IRequest<string> { }
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public LoginHandler(IUserService userService, IJwtProvider jwtProvider,
            IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByUserName(request.username);
            if (user is null)
            {
                throw new InvalidCredentials($"Bad credentials");
            }
            if (!_passwordHasher.Verify(request.password, user.Password))
            {
                throw new InvalidCredentials($"Bad credentials");
            }

            string token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
