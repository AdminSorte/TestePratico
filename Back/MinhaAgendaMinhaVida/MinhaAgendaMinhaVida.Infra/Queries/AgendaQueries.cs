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
    }
}