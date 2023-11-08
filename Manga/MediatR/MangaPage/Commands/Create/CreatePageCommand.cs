using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Create
{
    public record CreatePageCommand : IRequest<MangaPageDto>
    {
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public Guid ChapterId { get; set; }
    }
}
