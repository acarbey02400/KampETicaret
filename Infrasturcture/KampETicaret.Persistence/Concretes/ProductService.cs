using KampETicaret.Application.Abstractions;
using KampETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProductsList()
        {
            return new()
            {
               new(){ Id=Guid.NewGuid(), Name="product 1", Price=100, Stock=15},
               new(){ Id=Guid.NewGuid(), Name="product 2", Price=200, Stock=25},
               new(){ Id=Guid.NewGuid(), Name="product 3", Price=300, Stock=35},
               new(){ Id=Guid.NewGuid(), Name="product 4", Price=400, Stock=45},
               new(){ Id=Guid.NewGuid(), Name="product 5", Price=500, Stock=55}
            };
        }
    }
}
