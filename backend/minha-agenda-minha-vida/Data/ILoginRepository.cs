using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Data
{
    public interface ILoginRepository
    {
        User MakeLogin(string name, string password);
    }
}