using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.ChapterFeatures.Queries.GetAllByTitle
{
    public record GetAllChaptersByTitleRequest(Guid id) : IRequest<List<MangaChapterDto>> { }
    public class GetAllChaptersByTitleHandler : IRequestHandler<GetAllChaptersByTitleRequest, List<MangaChapterDto>>
    {
        private readonly IMangaTitleService _titleService;
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public GetAllChaptersByTitleHandler(IMangaTitleService titleService, IMangaChapterService chapterService, IMapper mapper)
        {
            _titleService = titleService;
            _chapterService = chapterService;
            _mapper = mapper;
        }
        async Task<List<MangaChapterDto>> IRequestHandler<GetAllChaptersByTitleRequest, List<MangaChapterDto>>.Handle(GetAllChaptersByTitleRequest request, CancellationToken cancellationToken)
        {
            var title = await _titleService.GetByIdAsync(request.id);
            if (title is null)
            {
                throw new NotFoundException($"There is no title with id {request.id}");
            }
            var chapters = await _chapterService.GetAllByTitleAsync(title);
            return _mapper.Map<List<MangaChapterDto>>(chapters);
        }
    }
}
