using SO.Agenda.Domain.Model.Entities;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Model.Interfaces.Services
{
    public interface ITaskItemService : IBaseService<TaskItem>
    {
        Task<TaskItem> GetByTitle(string title);
    }
}
