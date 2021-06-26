using MinhaAgendaMinhaVida.Domain.ViewModel;

namespace MinhaAgendaMinhaVida.Domain.Interfaces.Service
{
    public interface ISampleService
    {
        SampleViewModel Get(int id);
    }
}