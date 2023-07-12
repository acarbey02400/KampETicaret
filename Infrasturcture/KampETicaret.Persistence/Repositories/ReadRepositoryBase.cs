using KampETicaret.Application.RepositoryService;
using KampETicaret.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Persistence.Repositories
{
    public class ReadRepositoryBase<TEntity, TDbContext> : IReadRepository<TEntity> 
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        protected TDbContext _dbContext;

        public ReadRepositoryBase(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? method = null, bool tracking = true)
        {
           IQueryable<TEntity> query= Table.AsQueryable();
            if (!tracking) { query.AsNoTracking(); }
            if (method != null) { return await query.Where(method).ToListAsync(); }
            
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            IQueryable<TEntity> query = Table.AsQueryable();
            if (!tracking) { return await query.FirstOrDefaultAsync(method); }
            return await Table.FirstOrDefaultAsync(method);
        }
    }
}
