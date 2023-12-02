using Manga.Application.Repositories;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Application.Features.ChapterFeatures.Commands.Like
{
    public record LikeChapterCommand(Guid chapterId, string username) : IRequest { }
    public class LikeChapterHandler : IRequestHandler<LikeChapterCommand>
    {
        private readonly IUserService _userService;
        private readonly IMangaChapterService _chapterService;

        public LikeChapterHandler(IUserService userService, IMangaChapterService chapterService)
        {
            _userService = userService;
            _chapterService = chapterService;
        }
        public async Task Handle(LikeChapterCommand request, CancellationToken cancellationToken)
        {
            User current = await _userService.GetByUserName(request.username);
            MangaChapter chapter = await _chapterService.GetByIdAsync(request.chapterId);
            chapter.Likes++;
            await _chapterService.LikeChapter(current, chapter);

        }
    }
}
