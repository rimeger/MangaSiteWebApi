using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Delete
{
    public record DeletePageCommand(Guid id) : IRequest { }
}
