using AutoMapper;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using MediatR;

namespace Manga.Application.Features.ChapterFeatures.Queries.GetById
{
    public record GetChapterByIdRequest(Guid id) : IRequest<MangaChapterDto> { }
    public class GetChapterByIdHandler : IRequestHandler<GetChapterByIdRequest, MangaChapterDto>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public GetChapterByIdHandler(IMangaChapterService chapterService, IMapper mapper)
        {
            _chapterService = chapterService;
            _mapper = mapper;
        }
        public async Task<MangaChapterDto> Handle(GetChapterByIdRequest request, CancellationToken cancellationToken)
        {
            var chapter = await _chapterService.GetByIdAsync(request.id);
            if(chapter is null)
            {
                throw new NotFoundException($"There is no chapter with id {request.id}");
            }
            return _mapper.Map<MangaChapterDto>(chapter);
        }
    }
}
