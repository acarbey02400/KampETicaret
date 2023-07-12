using KampETicaret.Application.RepositoryService.OrderRepositoryService;
using KampETicaret.Domain.Entities;
using KampETicaret.Persistence.Contexts;

namespace KampETicaret.Persistence.Repositories.OrderRepositories
{
    public class OrderWriteRepository : WriteRepositoryBase<Order, KampETicaretAPIDbContext>, IOrderWriteRepository
    {
        public OrderWriteRepository(KampETicaretAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
