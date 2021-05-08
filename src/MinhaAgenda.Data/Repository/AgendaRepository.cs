using MinhaAgenda.Data.Data;
using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MinhaAgenda.Data.Repository
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(MinhaAgendaContext agendaContext) : base(agendaContext){ }
        public Task<List<Agenda>> ObterPorDescricaoTodos(string Titulo)
        {
            return Db.Agendas.AsNoTrackingWithIdentityResolution().Where(p => p.Titulo.Contains(Titulo)).ToListAsync();
        }


        public override async Task<List<Agenda>> ObterTodos()
        {
            return await DbSet.AsNoTrackingWithIdentityResolution().Select(p => new Agenda(p.Titulo) {
            Id = p.Id,
            }).ToListAsync();
        }

      
    }
}
