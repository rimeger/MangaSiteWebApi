using AutoMapper;
using FluentValidation;
using Manga.Application.Exceptions;
using Manga.Application.Services.Interfaces;
using Manga.Domain.Entities;
using MediatR;

namespace Manga.Application.Features.ChapterFeatures.Commands.Update
{
    public record UpdateChapterCommand : IRequest
    {
        public Guid Id { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
    }
    public class UpdateChapterHandler : IRequestHandler<UpdateChapterCommand>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateChapterCommand> _validator;

        public UpdateChapterHandler(IMangaChapterService chapterService, IMapper mapper, IValidator<UpdateChapterCommand> validator)
        {
            _chapterService = chapterService;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task Handle(UpdateChapterCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var originalChapter = await _chapterService.GetByIdAsync(request.Id);
            if (originalChapter is null)
            {
                throw new NotFoundException($"There is no chapter with id {request.Id}");
            }

            await _chapterService.Untrack(originalChapter);
            var updatedChapter = _mapper.Map<MangaChapter>(request);
            updatedChapter.UpdatedDate = DateTime.Now;
            updatedChapter.CreatedDate = originalChapter.CreatedDate;
            updatedChapter.MangaTitle = originalChapter.MangaTitle;
            await _chapterService.UpdateAsync(updatedChapter);
        }
    }
}
