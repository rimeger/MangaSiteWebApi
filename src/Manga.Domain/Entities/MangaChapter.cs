using Manga.Domain.Common;

namespace Manga.Domain.Entities
{
    public class MangaChapter : BaseEntity
    {
        public string ChapterName { get; set; } = string.Empty;
        public int ChapterNumber { get; set; }
        public int Likes { get; set; }
        public MangaTitle MangaTitle { get; set; } = null!;
        public ICollection<MangaPage> Pages { get; set; } = new List<MangaPage>();
        public ICollection<UserChapter> UserChapters { get; set; } = new List<UserChapter>();
    }
}
