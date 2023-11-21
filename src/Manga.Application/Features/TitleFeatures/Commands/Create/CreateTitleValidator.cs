using FluentValidation;

namespace Manga.Application.Features.TitleFeatures.Commands.Create
{
    public class CreateTitleValidator : AbstractValidator<CreateTitleCommand>
    {
        public CreateTitleValidator()
        {
            RuleFor(command => command.TitleName).NotEmpty().MaximumLength(100);
            RuleFor(command => command.Author).NotEmpty().MaximumLength(50);
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.PosterUrl).NotEmpty().MaximumLength(255);
        }
    }
}
