using FluentValidation;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Features.TitleFeatures.Commands.Create;
using Manga.Application.Features.TitleFeatures.Commands.Delete;
using Manga.Application.Features.TitleFeatures.Commands.Update;
using Manga.Application.Features.TitleFeatures.Queries.GetAll;
using Manga.Application.Features.TitleFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manga.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaTitleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MangaTitleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllTitles()
        {
            return Ok(await _mediator.Send(new GetAllTitlesRequest()));
        }

        [HttpGet("{id:Guid}", Name = "GetTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTitleById(Guid id)
        {
            MangaTitleDto title;
            try 
            {
                title = await _mediator.Send(new GetTitleByIdRequest(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(title);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTitle([FromBody] CreateTitleCommand command)
        {
            MangaTitleDto title;
            try
            {
                title = await _mediator.Send(command);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("GetTitle", new { id = title.Id }, title);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateTitle([FromBody] UpdateTitleCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTitle(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteTitleCommand(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }
    }
}
