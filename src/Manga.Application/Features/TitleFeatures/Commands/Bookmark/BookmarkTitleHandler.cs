using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.TitleFeatures.Commands.Bookmark
{
    public record BookmarkTitleCommand(Guid titleId, string username) : IRequest { }
    public class BookmarkTitleHandler : IRequestHandler<BookmarkTitleCommand>
    {
        private readonly IUserService _userService;
        private readonly IMangaTitleService _titleService;

        public BookmarkTitleHandler(IUserService userService, IMangaTitleService titleService)
        {
            _userService = userService;
            _titleService = titleService;
        }

        public async Task Handle(BookmarkTitleCommand request, CancellationToken cancellationToken)
        {
            User current = await _userService.GetByUserName(request.username);
            MangaTitle title = await _titleService.GetByIdAsync(request.titleId);
            if (title is null)
            {
                throw new NotFoundException($"There is no title with id {request.titleId}");
            }

            var titles = await _userService.GetBookmarksAsync(current.Id);
            if (titles.Contains(title))
            {
                throw new AlreadyDoneException("Can't like same chapter twice");
            }

            title.Bookmarks++;

            await _titleService.BookmarkTitle(current, title);
        }
    }
}
