using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Interfaces;

namespace Agenda.Infrastructure.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AgendaDbContext _agendaDbContext;
        public AgendaRepository(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
        }
        public void Add(Models.Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public List<Models.Agenda> GetAll(Guid userId)
        {
            return _agendaDbContext.Agendas.Where(x => x.UserId == userId).ToList();
        }

        public Models.Agenda GetById(Guid id)
        {
            return _agendaDbContext.Agendas.FirstOrDefault(x=>x.Id == id);
        }

        public void Update(Models.Agenda agenda)
        {
            throw new NotImplementedException();
        }

        public void Save(Models.Agenda agenda)
        {
            if(agenda.Id == Guid.Empty)
            {
                agenda.DateCreated = DateTime.Now;
                agenda.Id = Guid.NewGuid();
                _agendaDbContext.Agendas.Add(agenda);
            }
            else
            {
                var x = _agendaDbContext.Agendas.Where(c => c.Id == agenda.Id).FirstOrDefault();
                agenda.DateUpdated = DateTime.Now;
                _agendaDbContext.Entry(x).CurrentValues.SetValues(agenda);
            }

            _agendaDbContext.SaveChanges();
        }

        public void Delete(Models.Agenda agenda)
        {
            _agendaDbContext.Remove(agenda);
            _agendaDbContext.SaveChanges();
        }
    }
}
