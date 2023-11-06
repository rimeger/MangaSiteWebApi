using AutoMapper;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Create
{
    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, MangaChapterDto>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;
        private readonly IMangaTitleService _titleService;

        public CreateChapterCommandHandler(IMangaChapterService chapterService, IMapper mapper, IMangaTitleService titleService)
        {
            _chapterService = chapterService;
            _mapper = mapper;
            _titleService = titleService;
        }
        public async Task<MangaChapterDto> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {
            var chapter = _mapper.Map<Models.MangaChapter>(request);
            var title = await _titleService.GetByIdAsync(request.MangaTitleId);
            chapter.Id = Guid.NewGuid();
            chapter.CreatedDate = DateTime.Now;
            chapter.UpdatedDate = DateTime.Now;
            chapter.MangaTitle = title;
            await _chapterService.CreateAsync(chapter);
            return _mapper.Map<MangaChapterDto>(chapter);
        }
    }
}
