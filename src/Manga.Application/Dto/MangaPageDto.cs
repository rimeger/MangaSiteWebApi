namespace Manga.Application.Dto
{
    public class MangaPageDto
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
