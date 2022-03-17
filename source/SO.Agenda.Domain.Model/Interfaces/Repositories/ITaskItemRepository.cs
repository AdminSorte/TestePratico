using SO.Agenda.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Model.Interfaces.Repositories
{
    public interface ITaskItemRepository : IBaseRepository<TaskItem>
    {
        Task<TaskItem> GetTaskItemByTitle(string title);
    }
}
