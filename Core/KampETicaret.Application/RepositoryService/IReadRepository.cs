using KampETicaret.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.RepositoryService
{
    public interface IReadRepository<TEntity> : IRepositoryService<TEntity>
        where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? method=null,bool tracking=true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
       
    }
}
