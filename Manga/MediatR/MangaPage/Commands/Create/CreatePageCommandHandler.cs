using AutoMapper;
using FluentValidation;
using Manga.Exceptions;
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
        private readonly IValidator<CreatePageCommand> _validator;

        public CreatePageCommandHandler(IMangaPageService pageService, IMapper mapper,
            IMangaChapterService chapterService, IValidator<CreatePageCommand> validator)
        {
            _pageService = pageService;
            _mapper = mapper;
            _chapterService = chapterService;
            _validator = validator;
        }
        public async Task<MangaPageDto> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var chapter = await _chapterService.GetByIdAsync(request.ChapterId);
            if(chapter is null)
            {
                throw new NotFoundException($"There is no chapter with id {request.ChapterId}");
            }            
            var page = _mapper.Map<Models.MangaPage>(request);
            page.Id = Guid.NewGuid();
            page.CreatedDate = DateTime.Now;
            page.UpdatedDate = DateTime.Now;
            page.MangaChapter = chapter;
            await _pageService.CreateAsync(page);
            return _mapper.Map<MangaPageDto>(page);
        }
    }
}
