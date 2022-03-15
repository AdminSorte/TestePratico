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
        public bool IsSatisfiedBy(string Title)
        {
            return _repository.GetByTitle(Title) == null;
        }
    }
}
