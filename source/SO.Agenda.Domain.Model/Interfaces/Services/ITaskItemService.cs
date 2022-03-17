using SO.Agenda.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Model.Interfaces.Services
{
    public interface ITaskItemService : IBaseService<TaskItem>
    {
        Task<TaskItem> GetTaskItemByTitle(string title);
    }
}
