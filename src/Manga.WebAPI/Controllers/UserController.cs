﻿using FluentValidation;
using Manga.Application.Exceptions;
using Manga.Application.Features.ChapterFeatures.Queries.GetAll;
using Manga.Application.Features.UserFeatures.Commands.Login;
using Manga.Application.Features.UserFeatures.Commands.Register;
using Manga.Application.Features.UserFeatures.Queries.GetLikedChapters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Manga.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            string token = string.Empty;
            try
            {
               token = await _mediator.Send(command);
            }
            catch (InvalidCredentials ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterCommand command)
        {
            string token = string.Empty;
            try
            {
                token = await _mediator.Send(command);
            }
            catch (InvalidCredentials ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(token);
        }

        [HttpGet("liked/chapters")]
        [Authorize]
        public async Task<ActionResult> LikedChapters()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            return Ok(await _mediator.Send(new GetLikedChaptersRequest(username)));
        }
    }
}
