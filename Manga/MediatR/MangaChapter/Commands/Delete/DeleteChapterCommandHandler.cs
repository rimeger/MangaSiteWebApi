using AutoMapper;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Delete
{
    public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand>
    {
        private readonly IMangaChapterService _chapterService;

        public DeleteChapterCommandHandler(IMangaChapterService chapterService)
        {
            _chapterService = chapterService;
        }
        public async Task Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = await _chapterService.GetByIdAsync(request.id);
            await _chapterService.RemoveAsync(chapter);
        }
    }
}
