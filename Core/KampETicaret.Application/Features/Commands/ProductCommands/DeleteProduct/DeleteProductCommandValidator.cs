using FluentValidation;

namespace KampETicaret.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
        }
    }
}
