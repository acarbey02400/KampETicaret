using KampETicaret.Application.RepositoryService.CustomerRepositoryService;
using KampETicaret.Application.RepositoryService.OrderRepositoryService;
using KampETicaret.Domain.Entities;
using KampETicaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Repositories.OrderRepositories
{
    public class OrderReadRepository : ReadRepositoryBase<Order, KampETicaretAPIDbContext>, IOrderReadRepository
    {
        public OrderReadRepository(KampETicaretAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
