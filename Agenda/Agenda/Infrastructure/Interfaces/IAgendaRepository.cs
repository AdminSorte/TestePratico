namespace Agenda.Infrastructure.Interfaces
{
    public interface IAgendaRepository
    {
        void Add(Agenda.Models.Agenda agenda);
        void Update(Agenda.Models.Agenda agenda);
        List<Models.Agenda> GetAll();
        Agenda.Models.Agenda GetById(int id);

    }
}
