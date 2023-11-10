using AutoMapper;
using FluentValidation;
using Manga.Exceptions;
using Manga.Services.IServices;
using MediatR;

namespace Manga.MediatR.MangaChapter.Commands.Update
{
    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand>
    {
        private readonly IMangaChapterService _chapterService;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateChapterCommand> _validator;

        public UpdateChapterCommandHandler(IMangaChapterService chapterService, IMapper mapper, IValidator<UpdateChapterCommand> validator)
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
            var updatedChapter = _mapper.Map<Models.MangaChapter>(request);
            updatedChapter.UpdatedDate = DateTime.Now;
            updatedChapter.CreatedDate = originalChapter.CreatedDate;
            updatedChapter.MangaTitle = originalChapter.MangaTitle;
            await _chapterService.UpdateAsync(updatedChapter);
        }
    }
}
