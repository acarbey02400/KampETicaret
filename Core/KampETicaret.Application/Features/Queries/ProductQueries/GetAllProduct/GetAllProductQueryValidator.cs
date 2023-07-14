using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Queries.ProductQueries.GetAllProduct
{
    public class GetAllProductQueryValidator:AbstractValidator<GetAllProductQuery>
    {
        public GetAllProductQueryValidator()
        {
            RuleFor(p => p.Pagination.Size).Must(p => p >= 0);
            RuleFor(p => p.Pagination.Page).Must(p => p >= 0);
        }
    }
}
