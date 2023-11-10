using FluentValidation;

namespace Manga.MediatR.MangaPage.Commands.Update
{
    public class UpdatePageCommandValidator : AbstractValidator<UpdatePageCommand>
    {
        public UpdatePageCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty();  
            RuleFor(p => p.PageNumber).NotEmpty().GreaterThan(0);  
            RuleFor(p => p.ImageUrl).NotEmpty().MaximumLength(255);  
        }
    }
}
