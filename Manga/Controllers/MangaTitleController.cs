using FluentValidation;
using Manga.Exceptions;
using Manga.MediatR.MangaTitle.Commands.Create;
using Manga.MediatR.MangaTitle.Commands.Delete;
using Manga.MediatR.MangaTitle.Commands.Update;
using Manga.MediatR.MangaTitle.Requests.GetAll;
using Manga.MediatR.MangaTitle.Requests.GetById;
using Manga.Models.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manga.Controllers
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
