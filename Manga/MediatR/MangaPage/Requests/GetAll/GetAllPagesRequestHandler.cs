using AutoMapper;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Requests.GetAll
{
    public class GetAllPagesRequestHandler : IRequestHandler<GetAllPagesRequest, List<MangaPageDto>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;

        public GetAllPagesRequestHandler(IMangaPageService pageService, IMapper mapper)
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
