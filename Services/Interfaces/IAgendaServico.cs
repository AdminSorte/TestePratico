using Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAgendaServico
    {
        Task<AgendaDTO> Criar(AgendaDTO agendaDTO);
        Task<AgendaDTO> Atualizar(AgendaDTO agendaDTO);
        Task Remove(long id);
        Task<AgendaDTO> Obter(long id);
        Task<List<AgendaDTO>> Obter();
        Task<List<AgendaDTO>> ObterTitulo(string titulo);
    }
}
