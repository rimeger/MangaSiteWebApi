using AutoMapper;
using Manga.Exceptions;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Requests.GetAllByChapter
{
    public class GetAllPagesByChapterRequestHandler : IRequestHandler<GetAllPagesByChapterRequest, List<MangaPageDto>>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;
        private readonly IMangaChapterService _chapterService;

        public GetAllPagesByChapterRequestHandler(IMangaPageService pageService, IMapper mapper, IMangaChapterService chapterService)
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
