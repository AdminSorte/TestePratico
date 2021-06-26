using System;
using System.Data;
using MinhaAgendaMinhaVida.Domain.Enum;

namespace MinhaAgendaMinhaVida.Domain.Interfaces.Infra
{
    public interface IConnectionManager : IDisposable
    {
        IDbTransaction trans { get; set; }
        ConnType type { get; set; }
        Lazy<IDbConnection> Conn { get; set; }

        void BeginMultiTransaction();
        void BeginTransaction();
        void RollBack();
        void CommitAll();
        void Commit();
    }
}