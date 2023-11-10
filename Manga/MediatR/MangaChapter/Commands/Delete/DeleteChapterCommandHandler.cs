using AutoMapper;
using Manga.Exceptions;
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
            if (chapter is null)
            {
                throw new NotFoundException($"There is no chapter with id {request.id}");
            }
            await _chapterService.RemoveAsync(chapter);
        }
    }
}
