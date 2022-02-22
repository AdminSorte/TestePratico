using MinhaAgendaMinhaVida.Models;

namespace MinhaAgendaMinhaVida.Services.Interfaces
{
    public interface IServicoDeAgenda
    {
        List<Agendamento> ObterAgendamentos(int usuarioId);
        List<Agendamento> ObterAgendamentos(int usuarioId, string texto);
        Agendamento ObterAgendamento(int usuarioId, int agendamentoId);
        Agendamento Adicionar(int usuarioId, Agendamento agendamento);
        Agendamento Atualizar(Agendamento agendamento);
        bool Remover(int usuarioId, int agendamentoId);

    }
}
