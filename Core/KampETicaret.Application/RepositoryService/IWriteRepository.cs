using KampETicaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.RepositoryService
{
    public interface IWriteRepository<TEntity> : IRepositoryService<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entity);
        Task<bool> RemoveAsync(TEntity entity);
        Task<bool> RemoveAsync(string id);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> SaveAsync();
    }
}
