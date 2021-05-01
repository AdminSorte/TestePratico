using System.Linq;
using Microsoft.EntityFrameworkCore;
using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Data
{
    public class Repository: IRepository
    {
        private readonly AgendaDbContext _context;
        public Repository(AgendaDbContext context){
            _context = context;
        }
        public void Add<T>(T entity) where T: class 
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T: class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T: class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Agenda [] GetAllAgendas()
        {
            IQueryable<Agenda> query = _context.Agendas;
            query = query.OrderBy(ag => ag.Id);

            return query.ToArray();
        }

        public Agenda GetAgendaById(int id)
        {
            IQueryable<Agenda> query = _context.Agendas;
            query = query.AsNoTracking().Where(ag => ag.Id == id);

            return query.FirstOrDefault();
        }
    }
}