using System;
using System.Data;
using MinhaAgendaMinhaVida.Domain.Enum;

namespace MinhaAgendaMinhaVida.Infra.Managers
{
    public abstract class BaseConnectionManager : IDisposable
    {
        public Lazy<IDbConnection> conn;
        public IDbTransaction trans;
        public ConnType type;

        public BaseConnectionManager()
        {
            type = ConnType.Single;
        }

        public void Dispose()
        {
            if (trans != null)
            {
                trans.Dispose();
                trans = null;
            }

            if (conn != null)
            {
                conn.Value.Dispose();
                conn = null;
            }

            GC.SuppressFinalize(this);
        }

        public void BeginMultiTransaction()
        {
            type = ConnType.Multiple;
            if (trans == null || trans.Connection == null)
                trans = conn.Value.BeginTransaction();
        }

        public void BeginTransaction()
        {
            if (trans == null || trans.Connection == null)
                trans = conn.Value.BeginTransaction();
        }

        public void RollBack()
        {
            trans.Rollback();
        }

        public void CommitAll()
        {
            try
            {
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                trans = null;
            }
        }

        public void Commit()
        {
            if (type == ConnType.Multiple)
                return;

            try
            {
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                trans.Dispose();
                trans = null;
            }
        }
    }
}