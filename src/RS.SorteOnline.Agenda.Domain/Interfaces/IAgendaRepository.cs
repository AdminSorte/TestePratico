

using RS.SorteOnline.Agenda.Domain.Models;

namespace RS.SorteOnline.Agenda.Domain.Interfaces
{
    public interface IAgendaRepository : IRepository<AgendaModel>
    {
        AgendaModel GetByDescricao(string descricao);
    }
}
