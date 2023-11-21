using FluentValidation;

namespace Manga.Application.Features.ChapterFeatures.Commands.Update
{
    public class UpdateChapterValidator : AbstractValidator<UpdateChapterCommand>
    {
        public UpdateChapterValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.ChapterName).NotEmpty().MaximumLength(100);
            RuleFor(p => p.ChapterNumber).NotEmpty().GreaterThan(0);
        }
    }
}
