using AutoMapper;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Requests.GetAll
{
    public class GetAllChaptersRequestHandler : IRequestHandler<GetAllChaptersRequest, List<MangaChapterDto>>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public GetAllChaptersRequestHandler(IMangaChapterService chapterService, IMapper mapper)
        {
            _chapterService = chapterService;
            _mapper = mapper;
        }
        public async Task<List<MangaChapterDto>> Handle(GetAllChaptersRequest request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterService.GetAllAsync();
            return _mapper.Map<List<MangaChapterDto>>(chapters);
        }
    }
}
