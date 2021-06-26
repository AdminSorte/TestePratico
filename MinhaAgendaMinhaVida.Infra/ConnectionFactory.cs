using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MinhaAgendaMinhaVida.CrossCutting;

namespace MinhaAgendaMinhaVida.Infra
{
    public class ConnectionFactory
    {
        public static DbConnection GetMinhaAgendaMinhaVidaOpenConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.MinhaAgendaMinhaVidaConnection);

            if (connection.State != ConnectionState.Open) connection.Open();

            return connection;
        }
    }
}