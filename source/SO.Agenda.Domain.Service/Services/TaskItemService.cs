using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Repositories;
using SO.Agenda.Domain.Model.Interfaces.Services;
using SO.Agenda.Domain.Service.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Service.Services
{
    public class TaskItemService : BaseService<TaskItem>, ITaskItemService
    {
        private readonly ITaskItemRepository _repository;
        private readonly TaskItemMustHaveUniqueTitle _specification;
        public TaskItemService(ITaskItemRepository repository, TaskItemMustHaveUniqueTitle specification) : base(repository)
        {
            _repository = repository;
            _specification = specification;
        }
        public override Task<TaskItem> AddAsync(TaskItem TaskItem)
        {
            //Validação não contida nos requerimentos.
            if (!_specification.IsSatisfiedBy(TaskItem.Title, TaskItem.Id))
                throw new Exception("Já existe uma tarefa cadastrada com este título.");

            return _repository.AddAsync(TaskItem);
        }
        public override TaskItem Update(TaskItem TaskItem)
        {
            //Validação não contida nos requerimentos.
            if (!_specification.IsSatisfiedBy(TaskItem.Title, TaskItem.Id))
                throw new Exception("Já existe uma tarefa cadastrada com este título.");

            return _repository.Update(TaskItem);
        }
        public Task<TaskItem> GetTaskItemByTitle(string title)
        {
            return _repository.GetTaskItemByTitle(title);
        }

    }
}
