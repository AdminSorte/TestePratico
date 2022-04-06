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

        public List<Models.Agenda> GetAll()
        {
            return _agendaDbContext.Agendas.ToList();
        }

        public Models.Agenda GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Agenda agenda)
        {
            throw new NotImplementedException();
        }
    }
}
