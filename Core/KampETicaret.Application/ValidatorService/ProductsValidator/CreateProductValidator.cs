using FluentValidation;
using KampETicaret.Application.Dtos;
using KampETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.ValidatorService.ProductsValidator
{
    public class CreateProductValidator:AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
          RuleFor(p=>p.Name).NotEmpty().NotNull();
          RuleFor(p=>p.Price).NotEmpty().NotNull().Must(p => p >= 0);
          RuleFor(p => p.stock).NotEmpty().NotNull().Must(p=>p>=0);
        }
    }
}
