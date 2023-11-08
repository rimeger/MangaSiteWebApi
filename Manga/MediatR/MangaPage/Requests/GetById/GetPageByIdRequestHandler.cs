using AutoMapper;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Requests.GetById
{
    public class GetPageByIdRequestHandler : IRequestHandler<GetPageByIdRequest, MangaPageDto>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;

        public GetPageByIdRequestHandler(IMangaPageService pageService, IMapper mapper)
        {
            _pageService = pageService;
            _mapper = mapper;
        }
        public async Task<MangaPageDto> Handle(GetPageByIdRequest request, CancellationToken cancellationToken)
        {
            var page = await _pageService.GetByIdAsync(request.id);
            return _mapper.Map<MangaPageDto>(page);
        }
    }
}
