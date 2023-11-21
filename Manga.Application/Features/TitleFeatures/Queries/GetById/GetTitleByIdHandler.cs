using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.TitleFeatures.Queries.GetById
{
    public record GetTitleByIdRequest(Guid id) : IRequest<MangaTitleDto> { }
    public class GetTitleByIdHandler : IRequestHandler<GetTitleByIdRequest, MangaTitleDto>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;

        public GetTitleByIdHandler(IMangaTitleService titleService, IMapper mapper)
        {
            _titleService = titleService;
            _mapper = mapper;
        }
        public async Task<MangaTitleDto> Handle(GetTitleByIdRequest request, CancellationToken cancellationToken)
        {
            var title = await _titleService.GetByIdAsync(request.id);
            if (title is null)
            {
                throw new NotFoundException($"There is no title with id {request.id}");
            }
            return _mapper.Map<MangaTitleDto>(title);
        }
    }
}
