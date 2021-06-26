namespace MinhaAgendaMinhaVida.Infra.Repositories
{
    public partial class AgendaRepository
    {
        #region QueryListByFilters

        private const string QueryListByFilters = @"
            SELECT
                a.Id,
                a.Titulo,
                a.Descricao,
                a.Data
            FROM
                Agenda a WITH (NOLOCK)
            WHERE
                (@Titulo = '' OR a.Titulo LIKE CONCAT('%', @Titulo, '%'));";

        #endregion

        #region QueryAdd

        private const string QueryAdd = @"
            INSERT INTO Agenda
                (
                    Titulo,
                    Descricao,
                    [Data]
                )
            OUTPUT inserted.Id
            VALUES
                (
                    @Titulo, @Descricao, @Data
                );";

        #endregion

        #region QueryView

        private const string QueryView = @"
            SELECT
                a.Id,
                a.Titulo,
                a.Descricao,
                a.Data
            FROM
                Agenda a WITH (NOLOCK)
            WHERE
                a.Id = @Id;";

        #endregion

        #region QueryDelete

        private const string QueryDelete = @"DELETE FROM Agenda WHERE Id = @Id;";

        #endregion
    }
}