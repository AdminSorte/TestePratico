using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Infrastructure.Data.Repositories
{
    public class TaskItemRepository : BaseRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(AgendaContext context) : base(context)
        {
        }
        public async Task<TaskItem> GetByTitle(string title)
        {

            return await GetFirst(c => c.Title == title);
        }
    }
}
