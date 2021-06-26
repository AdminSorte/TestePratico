using System;
using System.Data;

namespace MinhaAgendaMinhaVida.Infra.Managers
{
    public class MinhaAgendaMinhaVidaConnectionManager : BaseConnectionManager
    {
        public MinhaAgendaMinhaVidaConnectionManager()
        {
            conn = new Lazy<IDbConnection>(() => ConnectionFactory.GetMinhaAgendaMinhaVidaOpenConnection());
        }
    }
}