using SO.Agenda.Application.AppServices.Interfaces;
using SO.Agenda.Application.ViewModels;
using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Services;
using SO.Agenda.Domain.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Application.AppServices.Implementations
{
    public class TaskItemAppService : BaseAppService<ITaskItemService, TaskItem, TaskItemViewModel>, ITaskItemAppService
    {
        public TaskItemAppService(ITaskItemService repository, IUnitOfWork uoW)
            : base(repository, uoW)
        {
        }
    }
}
