using MinhaAgendaMinhaVida.Domain.Model;

namespace MinhaAgendaMinhaVida.Domain.Interfaces.Infra
{
    public interface ISampleRepository
    {
        Sample Get(int id);
    }
}