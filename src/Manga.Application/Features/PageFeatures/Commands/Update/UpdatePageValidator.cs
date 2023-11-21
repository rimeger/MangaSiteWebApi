using FluentValidation;

namespace Manga.Application.Features.PageFeatures.Commands.Update
{
    public class UpdatePageValidator : AbstractValidator<UpdatePageCommand>
    {
        public UpdatePageValidator()
        {
            RuleFor(p => p.Id).NotEmpty();  
            RuleFor(p => p.PageNumber).NotEmpty().GreaterThan(0);  
            RuleFor(p => p.ImageUrl).NotEmpty().MaximumLength(255);  
        }
    }
}
