using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Infrastructure.Data.Repositories
{
    public class TaskItemRepository : BaseRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(AgendaContext context) : base(context)
        {
        }
    }
}
