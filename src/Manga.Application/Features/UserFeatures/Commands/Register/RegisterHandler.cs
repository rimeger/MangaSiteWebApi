using AutoMapper;
using FluentValidation;
using Manga.Application.Abstractions;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.UserFeatures.Commands.Register
{
    public record RegisterCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IValidator<RegisterCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterHandler(IUserService userService, IValidator<RegisterCommand> validator,
            IMapper mapper, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _validator = validator;
            _mapper = mapper;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var existingUser = await _userService.GetByUserName(request.UserName);
            if (existingUser is not null)
            {
                throw new InvalidCredentials($"Username is already taken");
            }

            var user = _mapper.Map<User>(request);
            user.Password = _passwordHasher.Hash(request.Password);
            user.Id = Guid.NewGuid();
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            user.Role = "User";

            await _userService.CreateAsync(user);

            string token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
