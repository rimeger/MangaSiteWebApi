using Manga.Models;
using Manga.Models.Dto;
using MediatR;

namespace Manga.MediatR.MangaTitle.Requests.GetAll
{
    public record GetAllTitlesRequest : IRequest<List<MangaTitleDto>> { }
}
