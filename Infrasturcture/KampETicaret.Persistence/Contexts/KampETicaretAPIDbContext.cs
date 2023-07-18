using KampETicaret.Domain.Entities;
using KampETicaret.Domain.Entities.Common;
using KampETicaret.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Contexts
{
    public class KampETicaretAPIDbContext :DbContext
    {
        protected IConfiguration Configuration;
        public KampETicaretAPIDbContext(DbContextOptions<KampETicaretAPIDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(a =>
            {
                a.ToTable("Products").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Price).HasColumnName("Price");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.Stock).HasColumnName("Stock");
                a.HasMany(p => p.Orders);
            });
            modelBuilder.Entity<Order>(a =>
            {
                a.ToTable("Orders").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Address).HasColumnName("Address");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.Property(p => p.CustomerId).HasColumnName("CustomerId");
                a.HasOne(p => p.Customer);
            });
            modelBuilder.Entity<Customer>(a =>
            {
                a.ToTable("Customers").HasKey(p => p.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                a.HasMany(p => p.Orders);
            });
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas= ChangeTracker.Entries<BaseEntity>();
            foreach (var item in datas)
            {
                if (item.State == EntityState.Modified) { item.Entity.UpdatedDate = DateTime.Now; }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
