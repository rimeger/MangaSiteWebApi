using AutoMapper;
using FluentValidation;
using Manga.Application.Dto;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.ChapterFeatures.Commands.Create
{
    public record CreateChapterCommand : IRequest<MangaChapterDto>
    {
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public Guid MangaTitleId { get; set; }
    }

    public class CreateChapterHandler : IRequestHandler<CreateChapterCommand, MangaChapterDto>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;
        private readonly IMangaTitleService _titleService;
        private readonly IValidator<CreateChapterCommand> _validator;

        public CreateChapterHandler(IMangaChapterService chapterService, IMapper mapper,
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

            var chapter = _mapper.Map<MangaChapter>(request);
            chapter.Id = Guid.NewGuid();
            chapter.CreatedDate = DateTime.Now;
            chapter.UpdatedDate = DateTime.Now;
            chapter.MangaTitle = title;
            await _chapterService.CreateAsync(chapter);
            return _mapper.Map<MangaChapterDto>(chapter);
        }
    }
}
