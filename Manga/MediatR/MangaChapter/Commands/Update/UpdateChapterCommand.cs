using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Update
{
    public record UpdateChapterCommand : IRequest
    {
        public Guid Id { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
    }
}
