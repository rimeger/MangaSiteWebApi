using FluentValidation;

namespace Manga.MediatR.MangaTitle.Commands.Update
{
    public class UpdateTitleCommandValidator : AbstractValidator<UpdateTitleCommand>
    {
        public UpdateTitleCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.TitleName).NotEmpty().MaximumLength(100);
            RuleFor(command => command.Author).NotEmpty().MaximumLength(50);
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.PosterUrl).NotEmpty().MaximumLength(255);
        }
    }
}
