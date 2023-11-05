using Manga.MediatR.MangaTitle.Commands.Create;
using Manga.MediatR.MangaTitle.Commands.Delete;
using Manga.MediatR.MangaTitle.Commands.Update;
using Manga.MediatR.MangaTitle.Requests.GetAll;
using Manga.MediatR.MangaTitle.Requests.GetById;
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

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTitleById(Guid id)
        {
            return Ok(await _mediator.Send(new GetTitleByIdRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTitle([FromBody] CreateTitleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTitle([FromBody] UpdateTitleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteMangaTitle(Guid id)
        {
            await _mediator.Send(new DeleteTitleCommand(id));
            return NoContent();
        }
    }
}
