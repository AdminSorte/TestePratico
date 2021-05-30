using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
   public interface IBaseRepositorio<T> where T : Base
   {
        Task<T> Criar(T objeto);
        Task<T> Atualizar(T objeto);
        Task Remover(long id);
        Task<T> Obter(long id);
        Task<List<T>> Obter();

   }
}
