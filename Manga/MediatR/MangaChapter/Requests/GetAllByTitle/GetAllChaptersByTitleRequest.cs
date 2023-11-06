using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaChapter.Requests.GetAllByTitle
{
    public record GetAllChaptersByTitleRequest(Guid id) : IRequest<List<MangaChapterDto>> { }
}
