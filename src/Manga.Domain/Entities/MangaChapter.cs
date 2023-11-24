using Manga.Domain.Common;

namespace Manga.Domain.Entities
{
    public class MangaChapter : BaseEntity
    {
        public string ChapterName { get; set; } = string.Empty;
        public int ChapterNumber { get; set; }
        public MangaTitle MangaTitle { get; set; } = null!;
        public ICollection<MangaPage> Pages { get; set; } = new List<MangaPage>();
    }
}
