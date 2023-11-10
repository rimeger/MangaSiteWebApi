using FluentValidation;

namespace Manga.MediatR.MangaPage.Commands.Create
{
    public class CreatePageCommandValidator : AbstractValidator<CreatePageCommand>
    {
        public CreatePageCommandValidator()
        {
            RuleFor(p => p.PageNumber).NotEmpty().GreaterThan(0);
            RuleFor(p => p.ImageUrl).NotEmpty().MaximumLength(255);
            RuleFor(p => p.ChapterId).NotEmpty();
        }
    }
}
