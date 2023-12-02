namespace Manga.Domain.Entities
{
    public class UserTitle
    {
        public Guid TitleId { get; set; }
        public Guid UserId { get; set; }
        public MangaTitle MangaTitle { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
