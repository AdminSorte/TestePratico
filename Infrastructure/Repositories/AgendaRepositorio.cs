using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AgendaRepositorio : BaseRepositorio<Agenda>, IAgendaRepositorio
    {
        private readonly AgendaContext _context;

        public virtual async Task<Agenda> ObterTitulo(string titulo)
        {
            var agenda = await _context.Agendas
                         .Where
                         (
                             x =>
                                 x.Titulo.ToLower() == titulo.ToLower()
                          )
                         .AsNoTracking()
                         .ToListAsync();

            return agenda.FirstOrDefault();
        }
    }
}
