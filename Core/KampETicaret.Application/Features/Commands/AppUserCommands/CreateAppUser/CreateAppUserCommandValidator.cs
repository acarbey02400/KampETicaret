using FluentValidation;

namespace KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser
{
    public class CreateAppUserCommandValidator : AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserCommandValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().NotNull();
            RuleFor(p => p.UserName).NotEmpty().NotNull();
            RuleFor(p => p.Email).NotEmpty().NotNull();
            RuleFor(p => p.Password).NotEmpty().NotNull();
        }
    }
}
