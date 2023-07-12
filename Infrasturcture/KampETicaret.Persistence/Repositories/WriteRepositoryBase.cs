using KampETicaret.Application.RepositoryService;
using KampETicaret.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Repositories
{
    public class WriteRepositoryBase<TEntity, TDbContext> : IWriteRepository<TEntity>
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        public WriteRepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            await SaveAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entity)
        {
            await _dbContext.AddRangeAsync(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<bool> RemoveAsync(TEntity entity)
        {
           _dbContext.Entry(entity).State = EntityState.Deleted;
            await SaveAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
           _dbContext.Entry(Table.Where(p => p.Id ==Guid.Parse(id))).State=EntityState.Deleted;
            await SaveAsync();
            return true;
        }

        

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return entity;
        }
        public async Task<int> SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
