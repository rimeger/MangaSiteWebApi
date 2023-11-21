using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.TitleFeatures.Queries.GetAll
{
    public record GetAllTitlesRequest : IRequest<List<MangaTitleDto>> { }
    public class GetAllTitlesHandler : IRequestHandler<GetAllTitlesRequest, List<MangaTitleDto>>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;

        public GetAllTitlesHandler(IMangaTitleService titleService, IMapper mapper)
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
