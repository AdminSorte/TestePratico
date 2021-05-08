using MinhaAgenda.Data.Data;
using MinhaAgenda.Domain.Interfaces;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace MinhaAgenda.Data.Repository
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(MinhaAgendaContext agendaContext) : base(agendaContext) { }
        public async Task<List<Agenda>> ObterPorTituloTodos(string Titulo)
        {
            return await Db.Agendas.AsNoTrackingWithIdentityResolution().Where(p => p.Titulo.Contains(Titulo)).ToListAsync();
        }


        public override async Task<List<Agenda>> ObterTodos()
        {
            return await DbSet.AsNoTrackingWithIdentityResolution().Select(p => new Agenda(p.Titulo)
            {
                Id = p.Id,
            }).ToListAsync();

        }


        public override async Task Atualizar(Agenda agenda)
        {
            var Procedure = "AtualizarAgenda";

            await Db.Database.GetDbConnection().QueryAsync(Procedure, 
                new { Id = agenda.Id ,Titulo = agenda.Titulo,Descricao = agenda.Descricao
                ,DataAgedamento =  agenda.DataAgedamento },commandType : CommandType.StoredProcedure);

        }
    }
}
