using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.PageFeatures.Queries.GetById
{
    public record GetPageByIdRequest(Guid id) : IRequest<MangaPageDto> { }
    public class GetPageByIdHandler : IRequestHandler<GetPageByIdRequest, MangaPageDto>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;

        public GetPageByIdHandler(IMangaPageService pageService, IMapper mapper)
        {
            _pageService = pageService;
            _mapper = mapper;
        }
        public async Task<MangaPageDto> Handle(GetPageByIdRequest request, CancellationToken cancellationToken)
        {
            var page = await _pageService.GetByIdAsync(request.id);
            if(page is null)
            {
                throw new NotFoundException($"There is no page with id {request.id}");
            }
            return _mapper.Map<MangaPageDto>(page);
        }
    }
}
