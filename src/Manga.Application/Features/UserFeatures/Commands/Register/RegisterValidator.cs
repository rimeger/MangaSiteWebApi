using FluentValidation;

namespace Manga.Application.Features.UserFeatures.Commands.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Password).NotEmpty().MinimumLength(8)
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }
    }
}
