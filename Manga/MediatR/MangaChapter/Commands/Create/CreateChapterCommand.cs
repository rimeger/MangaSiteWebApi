using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Create
{
    public record CreateChapterCommand : IRequest<MangaChapterDto>
    {
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public Guid MangaTitleId { get; set; }
    }
}
