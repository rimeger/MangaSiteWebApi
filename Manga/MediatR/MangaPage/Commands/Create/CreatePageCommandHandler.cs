using AutoMapper;
using Manga.Models.Dto;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaPage.Commands.Create
{
    public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, MangaPageDto>
    {
        private readonly IMangaPageService _pageService;
        private readonly IMapper _mapper;
        private readonly IMangaChapterService _chapterService;

        public CreatePageCommandHandler(IMangaPageService pageService, IMapper mapper, IMangaChapterService chapterService)
        {
            _pageService = pageService;
            _mapper = mapper;
            _chapterService = chapterService;
        }
        public async Task<MangaPageDto> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            var page = _mapper.Map<Models.MangaPage>(request);
            var chapter = await _chapterService.GetByIdAsync(request.ChapterId);
            page.Id = Guid.NewGuid();
            page.CreatedDate = DateTime.Now;
            page.UpdatedDate = DateTime.Now;
            page.MangaChapter = chapter;
            await _pageService.CreateAsync(page);
            return _mapper.Map<MangaPageDto>(page);
        }
    }
}
