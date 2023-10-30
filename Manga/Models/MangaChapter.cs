namespace Manga.Models
{
    public class MangaChapter
    {
        public Guid Id { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedName { get; set; }
        public MangaTitle MangaTitle { get; set; }
        public ICollection<MangaPage> Pages { get; set; } = new List<MangaPage>();
    }
}
