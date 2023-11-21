using FluentValidation;

namespace Manga.Application.Features.ChapterFeatures.Commands.Create
{
    public class CreateChapterValidator : AbstractValidator<CreateChapterCommand>
    {
        public CreateChapterValidator()
        {
            RuleFor(p => p.ChapterName).NotEmpty().MaximumLength(100);
            RuleFor(p => p.ChapterNumber).NotEmpty().GreaterThan(0);
            RuleFor(p => p.MangaTitleId).NotEmpty();
        }
    }
}
