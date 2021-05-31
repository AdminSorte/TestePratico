using System.Linq;
using RS.SorteOnline.Agenda.Domain.Interfaces;
using RS.SorteOnline.Agenda.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using RS.SorteOnline.Agenda.Domain.Models;

namespace RS.SorteOnline.Agenda.Infra.Data.Repository
{
    public class AgendaRepository : Repository<AgendaModel>, IAgendaRepository
    {
        public AgendaRepository(RSContext context)
            : base(context)
        {

        }

        public AgendaModel GetByDescricao(string descricao)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a=>a.Descricao.Contains(descricao));
        }
    }
}
