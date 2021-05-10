using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Domain.Interfaces
{
    public interface IAgendaService
    {
        Task<Agenda> ObterPorId(int id);

       public bool TesteAtualizaAgendasComRegras(Agenda agenda);
    }
}
