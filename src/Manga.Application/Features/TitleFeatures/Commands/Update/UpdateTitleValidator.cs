using FluentValidation;

namespace Manga.Application.Features.TitleFeatures.Commands.Update
{
    public class UpdateTitleValidator : AbstractValidator<UpdateTitleCommand>
    {
        public UpdateTitleValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.TitleName).NotEmpty().MaximumLength(100);
            RuleFor(command => command.Author).NotEmpty().MaximumLength(50);
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.PosterUrl).NotEmpty().MaximumLength(255);
        }
    }
}
