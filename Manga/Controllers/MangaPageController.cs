﻿using Manga.MediatR.MangaPage.Commands.Create;
using Manga.MediatR.MangaPage.Commands.Delete;
using Manga.MediatR.MangaPage.Commands.Update;
using Manga.MediatR.MangaPage.Requests.GetAll;
using Manga.MediatR.MangaPage.Requests.GetAllByChapter;
using Manga.MediatR.MangaPage.Requests.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Manga.Controllers
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetPageById(Guid id)
        {
            return Ok(await _mediator.Send(new GetPageByIdRequest(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePage([FromBody] CreatePageCommand command)
        {
            var page = await _mediator.Send(command);
            return CreatedAtRoute("GetPage", new { id = page.Id }, page);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePage([FromBody] UpdatePageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletePage(Guid id)
        {
            await _mediator.Send(new DeletePageCommand(id));
            return NoContent();
        }

        [HttpGet("MangaChapter/{chapterId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllPagesByChapter(Guid chapterId)
        {
            return Ok(await _mediator.Send(new GetAllPagesByChapterRequest(chapterId)));
        }
    }
}