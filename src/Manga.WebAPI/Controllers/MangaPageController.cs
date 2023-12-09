using FluentValidation;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Features.PageFeatures.Commands.Create;
using Manga.Application.Features.PageFeatures.Commands.Delete;
using Manga.Application.Features.PageFeatures.Commands.Update;
using Manga.Application.Features.PageFeatures.Queries.GetAll;
using Manga.Application.Features.PageFeatures.Queries.GetAllByChapter;
using Manga.Application.Features.PageFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manga.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaPageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MangaPageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllPages()
        {
            return Ok(await _mediator.Send(new GetAllPagesRequest()));
        }

        [HttpGet("{id:Guid}", Name = "GetPage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetPageById(Guid id)
        {
            MangaPageDto page;
            try
            {
                page = await _mediator.Send(new GetPageByIdRequest(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(page);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePage([FromBody] CreatePageCommand command)
        {
            MangaPageDto page;
            try
            {
                page = await _mediator.Send(command);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return CreatedAtRoute("GetPage", new { id = page.Id }, page);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePage([FromBody] UpdatePageCommand command)
        {
            try
            {
                await _mediator.Send(command);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
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
        public async Task<ActionResult> DeletePage(Guid id)
        {
            try
            {
                await _mediator.Send(new DeletePageCommand(id));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        [HttpGet("MangaChapter/{chapterId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllPagesByChapter(Guid chapterId)
        {
            List<MangaPageDto> pages;
            try
            {
                pages = await _mediator.Send(new GetAllPagesByChapterRequest(chapterId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(pages);
        }
    }
}
