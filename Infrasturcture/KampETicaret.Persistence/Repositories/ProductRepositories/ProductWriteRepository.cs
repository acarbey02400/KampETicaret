using KampETicaret.Application.RepositoryService.OrderRepositoryService;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Domain.Entities;
using KampETicaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepositoryBase<Product, KampETicaretAPIDbContext>, IProductWriteRepository
    {
        public ProductWriteRepository(KampETicaretAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
