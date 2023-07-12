using KampETicaret.Application.RepositoryService.CustomerRepositoryService;
using KampETicaret.Domain.Entities;
using KampETicaret.Persistence.Contexts;

namespace KampETicaret.Persistence.Repositories.CustomerRepositories
{
    public class CustomerReadRepository : ReadRepositoryBase<Customer, KampETicaretAPIDbContext>, ICustomerReadRepository
    {
        public CustomerReadRepository(KampETicaretAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
