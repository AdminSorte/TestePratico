using System.Collections.Generic;
using MinhaAgendaMinhaVida.Domain.Filter;
using MinhaAgendaMinhaVida.Domain.Model;

namespace MinhaAgendaMinhaVida.Domain.Interfaces.Infra
{
    public interface IAgendaRepository
    {
        IEnumerable<Agenda> List(SelectAgendaFilter filter);

        int Add(Agenda model);
    }
}