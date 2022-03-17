using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Domain.Service.Specifications
{
    public class TaskItemMustHaveUniqueTitle
    {
        private readonly ITaskItemRepository _repository;
        public TaskItemMustHaveUniqueTitle(ITaskItemRepository repository)
        {
            _repository = repository;
        }
        public bool IsSatisfiedBy(string Title, Int32 id)
        {
            List<TaskItem> taskItems = (List<TaskItem>)_repository.Get(x => x.Title == Title.Trim() && x.Id != id).Result;
            return taskItems.Count == 0;
        }
    }
}
