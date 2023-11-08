using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Create
{
    public record CreatePageCommand : IRequest<MangaPageDto>
    {
        public int PageNumber { get; set; }
        public string ImageUrl { get; set; }
        public Guid ChapterId { get; set; }
    }
}
