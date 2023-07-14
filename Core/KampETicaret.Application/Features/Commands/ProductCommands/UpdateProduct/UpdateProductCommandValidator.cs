using FluentValidation;

namespace KampETicaret.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.Price).NotEmpty().NotNull().Must(p => p >= 0);
            RuleFor(p => p.Stock).NotEmpty().NotNull().Must(p => p >= 0);
        }
    }
}
