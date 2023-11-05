using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaTitle.Requests.GetById
{
    public record GetTitleByIdRequest(Guid id) : IRequest<MangaTitleDto> { }
}
