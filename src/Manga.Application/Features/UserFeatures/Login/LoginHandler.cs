﻿using Manga.Application.Abstractions;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.UserFeatures.Login
{
    public record LoginCommand(string username, string password) : IRequest<string> { }
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IJwtProvider _jwtProvider;

        public LoginHandler(IUserService userService, IJwtProvider jwtProvider)
        {
            _userService = userService;
            _jwtProvider = jwtProvider;
        }

        async Task<string> IRequestHandler<LoginCommand, string>.Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByUserName(request.username);
            if(user is null)
            {
                throw new InvalidCredentials($"There is no user with {request.username} username");
            }
            if(!user.Password.Equals(request.password))
            {
                throw new InvalidCredentials($"Wrong password");
            }

            string token = _jwtProvider.Generate(user);

            return token;
        }
    }
}