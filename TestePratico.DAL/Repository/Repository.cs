using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.DAL.Interfaces;
using TestePratico.Model.Interface;

namespace TestePratico.DAL.Repository
{
    public class Repository : IDisposable, IRepository
    {
        private DbContext _objContext;

        public Repository(DbContext Context)
        {
            this._objContext = Context;
        }

        /// <summary>
        /// Adiciona um novo objeto.
        /// </summary>
        /// <param name="entity">Entidade</param>
        public void Add<E>(E entity) where E : class, IEntity
        {
            _objContext.Set<E>().Add(entity);
        }

        /// <summary>
        /// Atualiza um objeto existente.
        /// </summary>
        /// <param name="entity">Entidade</param>
        public void Update<E>(E entity) where E : class, IEntity
        {
            _objContext.Set<E>().Attach(entity);
            _objContext.Entry<E>(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Obtém um objeto do banco.
        /// </summary>
        /// <param name="id">ID do objeto</param>
        /// <returns>Entidade</returns>
        public E Get<E>(int id) where E : class, IEntity
        {
            return _objContext.Set<E>().Find(id);
        }

        /// <summary>
        /// Obtém todos os objetos do banco.
        /// </summary>
        /// <returns>Lista de entidades</returns>
        public List<E> GetAll<E>() where E : class, IEntity
        {
            return _objContext.Set<E>().ToList();
        }

        /// <summary>
        /// Possibilita criar uma consulta personalizada utilizando a interface IQueryable.
        /// </summary>
        /// <returns>Objeto IQueryable</returns>
        public IQueryable<E> Query<E>() where E : class, IEntity
        {
            return _objContext.Set<E>().AsQueryable<E>();
        }

        /// <summary>
        /// Remove o objeto do banco
        /// </summary>
        /// <param name="entity">Entidade</param>
        public void Remove<E>(E entity) where E : class, IEntity
        {
            if (_objContext.Entry(entity).State == EntityState.Detached)
                _objContext.Set<E>().Attach(entity);

            _objContext.Set<E>().Remove(entity);
        }

        /// <summary>
        /// Salva as alterações ocorridas no contexto.
        /// </summary>
        public int Save()
        {
            return _objContext.SaveChanges();
        }

        /// <summary>
        /// Retorna Objetos relacionados a uma Entidade
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="chave"></param>
        /// <returns></returns>
        public DbSet<E> Include<E>() where E : class, IEntity
        {
            return _objContext.Set<E>();
        }

        /// <summary>
        /// Libera os recursos.
        /// </summary>
        public void Dispose()
        {
            if (_objContext != null)
                _objContext.Dispose();
        }
    }
}
