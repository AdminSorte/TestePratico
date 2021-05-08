using Microsoft.EntityFrameworkCore;
using MinhaAgenda.Data.Data;
using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity,new() 
    {

        protected readonly MinhaAgendaContext Db;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(MinhaAgendaContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<int> Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
            return entity.Id;
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<bool> Existe(int id)
        {
            if (await Db.Agendas.AsNoTrackingWithIdentityResolution().CountAsync(p => p.Id == id) > 0)
            {
                return true;
            }

            return false;
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async  Task Remover(int id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public  async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
