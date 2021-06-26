using System.Data;
using MinhaAgendaMinhaVida.Infra.Managers;

namespace MinhaAgendaMinhaVida.Infra.Repositories
{
    public class BaseRepository
    {
        private readonly BaseConnectionManager _connectionManager;

        public BaseRepository(BaseConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IDbConnection _conn => _connectionManager.conn.Value;

        public IDbTransaction _trans => _connectionManager.trans;

        public void BeginTransaction()
        {
            _connectionManager.BeginTransaction();
        }

        public void RollBack()
        {
            _connectionManager.RollBack();
        }

        public void Commit()
        {
            _connectionManager.Commit();
        }
    }
}