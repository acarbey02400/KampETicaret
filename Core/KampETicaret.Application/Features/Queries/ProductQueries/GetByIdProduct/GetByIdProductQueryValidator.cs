using FluentValidation;

namespace KampETicaret.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQuery>
    {
        public GetByIdProductQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            
        }
    }
}
