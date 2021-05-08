using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Domain.Interfaces
{
   public interface IRepository<TEntity>
    {
        Task<int> Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(int id);
        
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(int id);

        Task<bool> Existe(int id);

        Task<int> SaveChanges();
    }
}
