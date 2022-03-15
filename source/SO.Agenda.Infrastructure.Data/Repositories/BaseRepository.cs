using Microsoft.EntityFrameworkCore;
using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        protected AgendaContext Ctx { get; }
        protected DbSet<TEntity> Set { get; }

        public BaseRepository(AgendaContext context)
        {
            Ctx = context;
            Set = Ctx.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity tEntity)
        {
            if (tEntity.Id == Guid.Empty)
                tEntity.Id = Guid.NewGuid();
            var entity = await Set.AddAsync(tEntity);
            return entity.Entity;
        }

        public virtual async Task<TEntity> FindAsync(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsNoTrackingAsync()
        {
            return await Set.AsNoTracking().ToListAsync();
        }

        public virtual TEntity Update(TEntity tEntity)
        {
            var entry = Ctx.Entry(tEntity);
            Set.Attach(tEntity);
            entry.State = EntityState.Modified;

            return tEntity;
        }

        public virtual void Remove(TEntity tEntity)
        {
            Set.Remove(tEntity);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            Set.Remove(await Set.FindAsync(id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Ctx?.Dispose();
            }
        }
    }
}
