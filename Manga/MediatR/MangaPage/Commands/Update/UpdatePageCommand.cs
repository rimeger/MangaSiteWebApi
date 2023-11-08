using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Update
{
    public record UpdatePageCommand : IRequest
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string ImageUrl { get; set; }
    }
}
