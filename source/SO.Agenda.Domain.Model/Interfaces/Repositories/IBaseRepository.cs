using SO.Agenda.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Model.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity tEntity);
        Task<TEntity> FindAsync(Int32 id);
        Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync();
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Update(TEntity tEntity);
        Task RemoveAsync(Int32 id);
        void Remove(TEntity tEntity);
        void Dispose();
    }
}
