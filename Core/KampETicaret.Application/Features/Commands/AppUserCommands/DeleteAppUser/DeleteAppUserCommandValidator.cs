using FluentValidation;

namespace KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser
{
    public class DeleteAppUserCommandValidator:AbstractValidator<DeleteAppUserCommand>
    {
        public DeleteAppUserCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
        }
    }
}
