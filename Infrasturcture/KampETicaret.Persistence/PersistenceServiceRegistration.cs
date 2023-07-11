using KampETicaret.Application.Abstractions;
using KampETicaret.Persistence.Concretes;
using KampETicaret.Persistence.Contexts;
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

            services.AddSingleton<IProductService, ProductService>();

        }
    }
}
