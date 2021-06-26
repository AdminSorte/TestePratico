using Dapper;
using MinhaAgendaMinhaVida.Domain.Interfaces.Infra;
using MinhaAgendaMinhaVida.Domain.Model;
using MinhaAgendaMinhaVida.Infra.Managers;

namespace MinhaAgendaMinhaVida.Infra.Repositories
{
    public partial class SampleRepository : BaseRepository, ISampleRepository
    {
        public SampleRepository(MinhaAgendaMinhaVidaConnectionManager connectionManager) : base(connectionManager)
        {
        }

        public Sample Get(int id)
        {
            return _conn.QueryFirstOrDefault<Sample>(QuerySelectById, new {Id = id});
        }
    }
}