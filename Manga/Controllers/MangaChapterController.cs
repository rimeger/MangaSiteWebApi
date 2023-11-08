using Manga.MediatR.MangaChapter.Commands.Create;
using Manga.MediatR.MangaChapter.Commands.Delete;
using Manga.MediatR.MangaChapter.Commands.Update;
using Manga.MediatR.MangaChapter.Requests.GetAll;
using Manga.MediatR.MangaChapter.Requests.GetAllByTitle;
using Manga.MediatR.MangaChapter.Requests.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manga.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaChapterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MangaChapterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllChapters()
        {
            return Ok(await _mediator.Send(new GetAllChaptersRequest()));
        }

        [HttpGet("{id:Guid}", Name = "GetChapter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetChapterById(Guid id)
        {
            return Ok(await _mediator.Send(new GetChapterByIdRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateChapter([FromBody] CreateChapterCommand command)
        {
            var chapter = await _mediator.Send(command);
            return CreatedAtRoute("GetChapter", new {id = chapter.Id}, chapter);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateChapter([FromBody] UpdateChapterCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteChapter(Guid id)
        {
            await _mediator.Send(new DeleteChapterCommand(id));
            return NoContent();
        }

        [HttpGet("MangaTitle/{titleId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllChaptersByTitle(Guid titleId)
        {
            return Ok(await _mediator.Send(new GetAllChaptersByTitleRequest(titleId)));
        }
    }
}
