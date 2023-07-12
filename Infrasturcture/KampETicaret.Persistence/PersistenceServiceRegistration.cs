using KampETicaret.Application.RepositoryService;
using KampETicaret.Application.RepositoryService.CustomerRepositoryService;
using KampETicaret.Application.RepositoryService.OrderRepositoryService;
using KampETicaret.Application.RepositoryService.ProductRepositories;
using KampETicaret.Persistence.Contexts;
using KampETicaret.Persistence.Repositories;
using KampETicaret.Persistence.Repositories.CustomerRepositories;
using KampETicaret.Persistence.Repositories.OrderRepositories;
using KampETicaret.Persistence.Repositories.ProductRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<KampETicaretAPIDbContext>(options =>
                                                    options.UseSqlServer(
                                                        configuration.GetConnectionString("KampETicaretAPIDbContext")));


            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
        
    }
}
