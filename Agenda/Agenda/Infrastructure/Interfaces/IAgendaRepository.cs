namespace Agenda.Infrastructure.Interfaces
{
    public interface IAgendaRepository
    {
        void Add(Agenda.Models.Agenda agenda);
        void Update(Agenda.Models.Agenda agenda);
        List<Models.Agenda> GetAll(Guid userId);
        Agenda.Models.Agenda GetById(Guid id);
        void Save(Models.Agenda agenda);

        void Delete(Models.Agenda agenda);

    }
}
