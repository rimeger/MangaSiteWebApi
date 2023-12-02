namespace Manga.Application.Dto
{
    public class MangaTitleDto
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int Bookmarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
