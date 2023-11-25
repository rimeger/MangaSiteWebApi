using FluentValidation;
using Manga.Application.Exceptions;
using Manga.Application.Features.UserFeatures.Login;
using Manga.Application.Features.UserFeatures.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
