using FluentValidation;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Features.ChapterFeatures.Commands.Create;
using Manga.Application.Features.ChapterFeatures.Commands.Delete;
using Manga.Application.Features.ChapterFeatures.Commands.Like;
using Manga.Application.Features.ChapterFeatures.Commands.Update;
using Manga.Application.Features.ChapterFeatures.Queries.GetAll;
using Manga.Application.Features.ChapterFeatures.Queries.GetAllByTitle;
using Manga.Application.Features.ChapterFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manga.WebAPI.Controllers
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
        public async Task<ActionResult> GetChapterById(Guid id)
        {
            MangaChapterDto chapter;
            try
            {
                chapter = await _mediator.Send(new GetChapterByIdRequest(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(chapter);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateChapter([FromBody] CreateChapterCommand command)
        {
            MangaChapterDto chapter;
            try
            {
                chapter = await _mediator.Send(command);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return CreatedAtRoute("GetChapter", new {id = chapter.Id}, chapter);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateChapter([FromBody] UpdateChapterCommand command)
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
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteChapter(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteChapterCommand(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpGet("MangaTitle/{titleId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllChaptersByTitle(Guid titleId)
        {
            List<MangaChapterDto> chapters;
            try
            {
                chapters = await _mediator.Send(new GetAllChaptersByTitleRequest(titleId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(chapters);
        }

        [HttpPost("like")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> LikeChapter(Guid id)
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            try
            {
                await _mediator.Send(new LikeChapterCommand(id, username));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyDoneException ex)
            {
                return BadRequest(ex.Message);
            }
            return NoContent();
        }
    }
}
