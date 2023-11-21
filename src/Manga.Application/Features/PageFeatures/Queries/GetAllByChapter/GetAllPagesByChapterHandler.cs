using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.PageFeatures.Queries.GetAllByChapter
{
    public record GetAllPagesByChapterRequest(Guid id) : IRequest<List<MangaPageDto>> { }
    public class GetAllPagesByChapterHandler : IRequestHandler<GetAllPagesByChapterRequest, List<MangaPageDto>>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;
        private readonly IMangaChapterService _chapterService;

        public GetAllPagesByChapterHandler(IMangaPageService pageService, IMapper mapper, IMangaChapterService chapterService)
        {
            _pageService = pageService;
            _mapper = mapper;
            _chapterService = chapterService;
        }
        public async Task<List<MangaPageDto>> Handle(GetAllPagesByChapterRequest request, CancellationToken cancellationToken)
        {
            var chapter = await _chapterService.GetByIdAsync(request.id);
            if(chapter is null)
            {
                throw new NotFoundException($"There is no chapter with id {request.id}");
            }
            var pages = await _pageService.GetAllByChapterAsync(chapter);
            return _mapper.Map<List<MangaPageDto>>(pages);
        }
    }
}
