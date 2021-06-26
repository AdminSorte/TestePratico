using System.Collections.Generic;
using Dapper;
using MinhaAgendaMinhaVida.CrossCutting.Extensions;
using MinhaAgendaMinhaVida.Domain.Filter;
using MinhaAgendaMinhaVida.Domain.Interfaces.Infra;
using MinhaAgendaMinhaVida.Domain.Model;
using MinhaAgendaMinhaVida.Infra.Managers;

namespace MinhaAgendaMinhaVida.Infra.Repositories
{
    public partial class AgendaRepository : BaseRepository, IAgendaRepository
    {
        public AgendaRepository(MinhaAgendaMinhaVidaConnectionManager connectionManager) : base(connectionManager)
        {
        }

        public IEnumerable<Agenda> List(SelectAgendaFilter filter)
        {
            return _conn.Query<Agenda>(QueryListByFilters.NormalizeWhiteSpaces(), filter);
        }
    }
}