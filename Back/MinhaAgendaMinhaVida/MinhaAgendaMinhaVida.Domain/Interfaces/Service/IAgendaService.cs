using System.Collections.Generic;
using MinhaAgendaMinhaVida.Domain.Commands.Agenda;
using MinhaAgendaMinhaVida.Domain.ViewModel;

namespace MinhaAgendaMinhaVida.Domain.Interfaces.Service
{
    public interface IAgendaService
    {
        IEnumerable<AgendaViewModel> List(SelectAgendaCommand command);
        int Add(InsertAgendaCommand command);
    }
}