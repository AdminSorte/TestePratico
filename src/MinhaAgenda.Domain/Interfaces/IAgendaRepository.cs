using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Domain.Interfaces
{
    public interface IAgendaRepository : IRepository<Agenda>
    {

        Task<List<Agenda>> ObterPorDescricaoTodos(string Titulo);

    }
}
