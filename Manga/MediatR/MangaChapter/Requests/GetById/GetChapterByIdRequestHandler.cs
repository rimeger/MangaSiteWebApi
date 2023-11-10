using AutoMapper;
using Manga.Exceptions;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Requests.GetById
{
    public class GetChapterByIdRequestHandler : IRequestHandler<GetChapterByIdRequest, MangaChapterDto>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;

        public GetChapterByIdRequestHandler(IMangaChapterService chapterService, IMapper mapper)
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
