using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull();
            RuleFor(p => p.Price).NotEmpty().NotNull().Must(p => p >= 0);
            RuleFor(p => p.Stock).NotEmpty().NotNull().Must(p => p >= 0);
        }
    }


}
