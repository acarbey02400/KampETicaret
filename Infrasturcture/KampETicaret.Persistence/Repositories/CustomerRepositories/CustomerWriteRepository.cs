using KampETicaret.Application.RepositoryService.CustomerRepositoryService;
using KampETicaret.Domain.Entities;
using KampETicaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Repositories.CustomerRepositories
{
    public class CustomerWriteRepository : WriteRepositoryBase<Customer, KampETicaretAPIDbContext>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(KampETicaretAPIDbContext dbContext) : base(dbContext)
        {
        }
    }
}
