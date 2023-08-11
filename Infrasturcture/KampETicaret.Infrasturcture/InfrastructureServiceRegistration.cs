using KampETicaret.Application.Abstractions.ApplicationServices.AspnetIdentityServices;
using KampETicaret.Application.Abstractions.TokenManager;
using KampETicaret.Infrasturcture.Services.IdentityServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Infrasturcture
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration builder)

        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin",options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidAudience = builder["TokenOptions:Audience"],
                     ValidIssuer = builder["TokenOptions:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder["TokenOptions:SecurityKey"])),
                     //Token süresinin dolup dolmadığını kontrol etmek için lifetimevalidator parametresini kullanıyoruz
                     LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires!=null ? expires>=DateTime.UtcNow:false
                 };
             });
            services.AddScoped<ITokenHandler,Services.TokenServices.TokenHandler>();
            services.AddScoped<IUserService, AspNetIdentityUserManager>();
            services.AddScoped<IAuthService,AspNetIdentityAuthManager>();
        }
    }
}
