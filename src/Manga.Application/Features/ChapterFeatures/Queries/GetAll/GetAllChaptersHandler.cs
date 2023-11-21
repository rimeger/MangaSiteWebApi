using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.ChapterFeatures.Queries.GetAll
{
    public record GetAllChaptersRequest : IRequest<List<MangaChapterDto>> { }
    public class GetAllChaptersHandler : IRequestHandler<GetAllChaptersRequest, List<MangaChapterDto>>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public GetAllChaptersHandler(IMangaChapterService chapterService, IMapper mapper)
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
