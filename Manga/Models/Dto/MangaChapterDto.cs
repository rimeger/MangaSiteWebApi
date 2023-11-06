namespace Manga.Models.Dto
{
    public class MangaChapterDto
    {
        public Guid Id { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
