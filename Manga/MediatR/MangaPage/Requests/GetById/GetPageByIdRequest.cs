using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaPage.Requests.GetById
{
    public record GetPageByIdRequest(Guid id) : IRequest<MangaPageDto> { }
}
