using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Domain.Entities;
using KampETicaret.Persistence.Contexts;

namespace KampETicaret.Persistence.Repositories.ProductRepositories
{
    public class ProductReadRepository : ReadRepositoryBase<Product, KampETicaretAPIDbContext>, IProductReadRepository
    {
        public ProductReadRepository(KampETicaretAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
