using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.PageFeatures.Queries.GetAll
{
    public record GetAllPagesRequest : IRequest<List<MangaPageDto>> { }
    public class GetAllPagesHandler : IRequestHandler<GetAllPagesRequest, List<MangaPageDto>>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;

        public GetAllPagesHandler(IMangaPageService pageService, IMapper mapper)
        {
            _pageService = pageService;
            _mapper = mapper;
        }
        public async Task<List<MangaPageDto>> Handle(GetAllPagesRequest request, CancellationToken cancellationToken)
        {
            var pages = await _pageService.GetAllAsync();
            return _mapper.Map<List<MangaPageDto>>(pages);
        }
    }
}
