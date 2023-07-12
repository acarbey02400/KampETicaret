using KampETicaret.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.RepositoryService
{
    public interface IRepositoryService<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
    }
}
