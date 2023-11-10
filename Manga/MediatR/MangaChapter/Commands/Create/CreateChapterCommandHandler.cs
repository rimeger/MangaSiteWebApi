using AutoMapper;
using FluentValidation;
using Manga.Exceptions;
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
        private readonly IValidator<CreateChapterCommand> _validator;

        public CreateChapterCommandHandler(IMangaChapterService chapterService, IMapper mapper,
            IMangaTitleService titleService, IValidator<CreateChapterCommand> validator)
        {
            _chapterService = chapterService;
            _mapper = mapper;
            _titleService = titleService;
            _validator = validator;
        }
        public async Task<MangaChapterDto> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var title = await _titleService.GetByIdAsync(request.MangaTitleId);
            if(title is null)
            {
                throw new NotFoundException($"There is no title with id {request.MangaTitleId}");
            }

            var chapter = _mapper.Map<Models.MangaChapter>(request);
            chapter.Id = Guid.NewGuid();
            chapter.CreatedDate = DateTime.Now;
            chapter.UpdatedDate = DateTime.Now;
            chapter.MangaTitle = title;
            await _chapterService.CreateAsync(chapter);
            return _mapper.Map<MangaChapterDto>(chapter);
        }
    }
}
