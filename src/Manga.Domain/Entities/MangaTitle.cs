using Manga.Domain.Common;

namespace Manga.Domain.Entities
{
    public class MangaTitle : BaseEntity
    {
        public string TitleName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<MangaChapter> Chapters { get; set; }
    }
}
