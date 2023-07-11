using KampETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProductsList();
    }
}
