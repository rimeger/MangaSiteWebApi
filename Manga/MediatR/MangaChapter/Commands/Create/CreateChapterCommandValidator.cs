using FluentValidation;

namespace Manga.MediatR.MangaChapter.Commands.Create
{
    public class CreateChapterCommandValidator : AbstractValidator<CreateChapterCommand>
    {
        public CreateChapterCommandValidator()
        {
            RuleFor(p => p.ChapterName).NotEmpty().MaximumLength(100);
            RuleFor(p => p.ChapterNumber).NotEmpty().GreaterThan(0);
            RuleFor(p => p.MangaTitleId).NotEmpty();
        }
    }
}
