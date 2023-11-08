using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaPage.Requests.GetAllByChapter
{
    public record GetAllPagesByChapterRequest(Guid id) : IRequest<List<MangaPageDto>> { }
}
