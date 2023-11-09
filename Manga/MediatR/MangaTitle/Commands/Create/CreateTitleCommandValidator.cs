using FluentValidation;

namespace Manga.MediatR.MangaTitle.Commands.Create
{
    public class CreateTitleCommandValidator : AbstractValidator<CreateTitleCommand>
    {
        public CreateTitleCommandValidator()
        {
            RuleFor(command => command.TitleName).NotEmpty().MaximumLength(100);
            RuleFor(command => command.Author).NotEmpty().MaximumLength(50);
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.PosterUrl).NotEmpty().MaximumLength(255);
        }
    }
}
