using SO.Agenda.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Application.AppServices.Interfaces
{
    public interface ITaskItemAppService : IBaseAppService<TaskItemViewModel>
    {
        Task<TaskItemViewModel> GetByTitle(string title);
    }
}
