using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Model.Interface;

namespace TestePratico.DAL.Interfaces
{
    public interface IRepository
    {
        void Add<E>(E entity) where E : class, IEntity;

        void Update<E>(E entity) where E : class, IEntity;

        void Remove<E>(E entity) where E : class, IEntity;

        E Get<E>(int id) where E : class, IEntity;

        List<E> GetAll<E>() where E : class, IEntity;

        IQueryable<E> Query<E>() where E : class, IEntity;

        DbSet<E> Include<E>() where E : class, IEntity;

        int Save();
    }
}