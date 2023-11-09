using AutoMapper;
using Manga.Exceptions;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaTitle.Requests.GetById
{
    public class GetTitleByIdRequestHandler : IRequestHandler<GetTitleByIdRequest, MangaTitleDto>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMapper _mapper;

        public GetTitleByIdRequestHandler(IMangaTitleService titleService, IMapper mapper)
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
