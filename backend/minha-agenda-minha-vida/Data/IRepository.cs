using System.Collections.Generic;
using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        bool SaveChanges();
        Agenda [] GetAllAgendas();
        Agenda GetAgendaById(int id);
    }
}