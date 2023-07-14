using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services) 
        {
           services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           services.AddAutoMapper(Assembly.GetExecutingAssembly());
           services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
