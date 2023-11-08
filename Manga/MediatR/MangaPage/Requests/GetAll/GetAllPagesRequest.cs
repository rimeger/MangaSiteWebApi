using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaPage.Requests.GetAll
{
    public record GetAllPagesRequest : IRequest<List<MangaPageDto>> { }
}
