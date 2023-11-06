using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaChapter.Requests.GetById
{
    public record GetChapterByIdRequest(Guid id) : IRequest<MangaChapterDto> { }
}
