using MinhaAgendaMinhaVida.Models;

namespace MinhaAgendaMinhaVida.Services.Interfaces
{
    public interface IServicoDeUsuario
    {
        Usuario Login(string login, string senha);

        Usuario GetUsuario(int usuarioId);
    }
}
