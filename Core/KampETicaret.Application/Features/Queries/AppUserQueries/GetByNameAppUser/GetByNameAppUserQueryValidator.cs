using FluentValidation;

namespace KampETicaret.Application.Features.Queries.AppUserQueries.GetByNameAppUser
{
    public class GetByNameAppUserQueryValidator : AbstractValidator<GetByNameAppUserQuery>
    {
        public GetByNameAppUserQueryValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().NotNull();
        }
    }
}
