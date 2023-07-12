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
        Task<TEntity> AddAsync(TEntity entity, bool tracking = true);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entity, bool tracking = true);
        Task<bool> RemoveAsync(TEntity entity, bool tracking = true);
        Task<bool> RemoveAsync(string id, bool tracking = true);
        Task<TEntity> UpdateAsync(TEntity entity, bool tracking = true);
        Task<int> SaveAsync();
    }
}
