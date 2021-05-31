using System;
using System.Collections.Generic;
using RS.SorteOnline.Agenda.Application.ViewModels;

namespace RS.SorteOnline.Agenda.Application.Interfaces
{
    public interface IAgendaAppService : IDisposable
    {
        void Register(AgendaViewModel AgendaViewModel);
        IEnumerable<AgendaViewModel> GetAll();
        AgendaViewModel GetById(int id);
        void Update(AgendaViewModel AgendaViewModel);
        void Remove(int id);
    }
}
