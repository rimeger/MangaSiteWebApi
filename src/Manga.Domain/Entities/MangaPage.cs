using Manga.Domain.Common;

namespace Manga.Domain.Entities
{
    public class MangaPage : BaseEntity
    {
        public int PageNumber { get; set; }
        public string ImageUrl { get; set; }
        public MangaChapter MangaChapter { get; set; }
    }
}
