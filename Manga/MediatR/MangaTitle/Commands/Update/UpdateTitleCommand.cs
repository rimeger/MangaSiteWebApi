using MediatR;

namespace Manga.MediatR.MangaTitle.Commands.Update
{
    public record UpdateTitleCommand : IRequest
    {
        public Guid Id { get; set; }
        public string TitleName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
    }
}
