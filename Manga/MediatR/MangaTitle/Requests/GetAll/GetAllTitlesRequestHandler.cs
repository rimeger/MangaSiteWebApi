using AutoMapper;
using Manga.Models;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaTitle.Requests.GetAll
{
    public class GetAllTitlesRequestHandler : IRequestHandler<GetAllTitlesRequest, List<MangaTitleDto>>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;

        public GetAllTitlesRequestHandler(IMangaTitleService titleService, IMapper mapper)
        {
            _titleService = titleService;
            _mapper = mapper;
        }
        public async Task<List<MangaTitleDto>> Handle(GetAllTitlesRequest request, CancellationToken cancellationToken)
        {
            var titles = await _titleService.GetAllAsync();
            return _mapper.Map<List<MangaTitleDto>>(titles);
        }
    }
}
