using MediatR;

namespace Manga.MediatR.MangaTitle.Commands.Delete
{
    public record DeleteTitleCommand(Guid id) : IRequest { }
}
