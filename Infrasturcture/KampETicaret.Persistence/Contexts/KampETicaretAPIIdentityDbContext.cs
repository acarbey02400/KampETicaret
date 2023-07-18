using KampETicaret.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Contexts
{
    public class KampETicaretAPIIdentityDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        protected IConfiguration Configuration;
        public KampETicaretAPIIdentityDbContext(DbContextOptions<KampETicaretAPIIdentityDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
    }
}
