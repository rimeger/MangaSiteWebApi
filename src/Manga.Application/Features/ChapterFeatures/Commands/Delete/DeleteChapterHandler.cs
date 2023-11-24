
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.ChapterFeatures.Commands.Delete
{
    public record DeleteChapterCommand(Guid id) : IRequest { }

    public class DeleteChapterHandler : IRequestHandler<DeleteChapterCommand>
    {
        private readonly IMangaChapterService _chapterService;

        public DeleteChapterHandler(IMangaChapterService chapterService)
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
            _chapterService.Remove(chapter);
        }
    }
}
