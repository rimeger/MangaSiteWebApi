using AutoMapper;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Requests.GetAllByTitle
{
    public class GetAllChaptersByTitleRequestHandler : IRequestHandler<GetAllChaptersByTitleRequest, List<MangaChapterDto>>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public GetAllChaptersByTitleRequestHandler(IMangaTitleService titleService, IMangaChapterService chapterService, IMapper mapper)
        {
            _titleService = titleService;
            _chapterService = chapterService;
            _mapper = mapper;
        }
        async Task<List<MangaChapterDto>> IRequestHandler<GetAllChaptersByTitleRequest, List<MangaChapterDto>>.Handle(GetAllChaptersByTitleRequest request, CancellationToken cancellationToken)
        {
            var title = await _titleService.GetByIdAsync(request.id);
            var chapters = await _chapterService.GetAllByTitleAsync(title);
            return _mapper.Map<List<MangaChapterDto>>(chapters);
        }
    }
}
