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

        public IEnumerable<Agenda> List(SelectAgendaFilter filter) => _conn.Query<Agenda>(QueryListByFilters.NormalizeWhiteSpaces(), filter);

        public int Add(Agenda model)
        {
            BeginTransaction();
            try
            {
                var id = _conn.ExecuteScalar<int>(QueryAdd.NormalizeWhiteSpaces(), model, _trans);

                Commit();

                return id;
            }
            catch
            {
                RollBack();
                throw;
            }
        }

        public Agenda View(int id) => _conn.QuerySingle<Agenda>(QueryView.NormalizeWhiteSpaces(), new { Id = id });

        public bool Delete(int id)
        {
            BeginTransaction();
            try
            {
                _conn.Execute(QueryDelete.NormalizeWhiteSpaces(), new { Id = id }, _trans);

                Commit();

                return true;
            }
            catch
            {
                RollBack();
                throw;
            }
        }

        public bool Edit(Agenda model)
        {
            BeginTransaction();
            try
            {
                _conn.Execute(QueryEdit.NormalizeWhiteSpaces(), model, _trans);

                Commit();

                return true;
            }
            catch
            {
                RollBack();
                throw;
            }
        }
    }
}