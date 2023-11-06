using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaChapter.Requests.GetAll
{
    public record GetAllChaptersRequest : IRequest<List<MangaChapterDto>> { }
}
