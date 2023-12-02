using FluentValidation;

namespace Manga.Application.Features.PageFeatures.Commands.Create
{
    public class CreatePageValidator : AbstractValidator<CreatePageCommand>
    {
        public CreatePageValidator()
        {
            RuleFor(p => p.ImageUrl).NotEmpty().MaximumLength(255);
            RuleFor(p => p.ChapterId).NotEmpty();
        }
    }
}
