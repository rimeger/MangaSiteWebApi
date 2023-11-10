using FluentValidation;

namespace Manga.MediatR.MangaChapter.Commands.Update
{
    public class UpdateChapterCommandValidator : AbstractValidator<UpdateChapterCommand>
    {
        public UpdateChapterCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.ChapterName).NotEmpty().MaximumLength(100);
            RuleFor(p => p.ChapterNumber).NotEmpty().GreaterThan(0);
        }
    }
}
