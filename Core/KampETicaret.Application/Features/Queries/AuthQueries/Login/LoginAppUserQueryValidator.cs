using FluentValidation;

namespace KampETicaret.Application.Features.Queries.AuthQueries.Login
{
    public class LoginAppUserQueryValidator : AbstractValidator<LoginAppUserQuery>
    {
        public LoginAppUserQueryValidator()
        {
            RuleFor(p => p.UserName).NotNull().NotEmpty();
            RuleFor(p => p.Password).NotNull().NotEmpty();
        }
    }
}
