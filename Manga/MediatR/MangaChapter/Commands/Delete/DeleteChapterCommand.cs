using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Delete
{
    public record DeleteChapterCommand(Guid id) : IRequest { }
}
