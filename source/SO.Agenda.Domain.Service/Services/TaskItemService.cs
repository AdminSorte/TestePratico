using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Domain.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Service.Services
{
    public class TaskItemService : BaseService<TaskItem>, ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        public TaskItemService(ITaskItemRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<TaskItem> GetByTitle(string title)
        {
            return _repository.GetByTitle(title);
        }
    }
}
