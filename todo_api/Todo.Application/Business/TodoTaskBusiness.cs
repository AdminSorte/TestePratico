using System;
using System.Linq;
using System.Threading.Tasks;
using Todo.Application.Business.Interface;
using Todo.Application.Dto.TodoTask;
using Todo.Application.Repository;
using Todo.Application.Response;
using Todo.Application.Service.Interface;
using Todo.Domain.Entities;

namespace Todo.Application.Business
{
    public class TodoTaskBusiness : ITodoTaskBusiness
    {
        private readonly ITodoTaskRepository _todoTaskRepository;
        private readonly IIdentityService _identityService;
        
        public TodoTaskBusiness(
            ITodoTaskRepository todoTaskRepository,
            IIdentityService identityService
        )
        {
            _todoTaskRepository = todoTaskRepository;
            _identityService = identityService;
        }

        public async Task<ResponseService> GetAllAsync(int userId)
        {
            try {
                var result = await _todoTaskRepository.GetAllAsync(_identityService.GetUserIdentity());

                var todoTasks = result.Select(x => new ResultTodoTaskDto {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                });

                return new ResponseService(todoTasks);
            }
            catch (Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        public async Task<ResponseService> CreateAsync(CreateTodoTaskDto data)
        {
            try {
                var todoTask = new TodoTask {
                    Title = data.Title,
                    Description = data.Description,
                    UserId = _identityService.GetUserIdentity()
                };

                var result = await _todoTaskRepository.CreateAsync(todoTask);

                return new ResponseService(result);
            }
            catch (Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        public async Task<ResponseService> UpdateAsync(UpdateTodoTaskDto data)
        {
            try {
                var todoTask = await _todoTaskRepository.GetById(data.Id);

                if (todoTask != null) {
                    todoTask.Title = data.Title;
                    todoTask.Description = data.Description;

                    var result = await _todoTaskRepository.UpdateAsync(todoTask);

                    return new ResponseService(result);
                }

                return new ResponseService(messageError: "Invalid todo task");
            }
            catch (Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }

        public async Task<ResponseService> RemoveAsync(int id)
        {
            try {
                var todoTask = await _todoTaskRepository.GetById(id);

                if (todoTask != null) {
                    var result = await _todoTaskRepository.RemoveAsync(id);

                    return new ResponseService(result);
                }

                return new ResponseService(messageError: "Invalid todo task");
            }
            catch (Exception ex) {
                return new ResponseService(messageError: ex.Message);
            }
        }
    }
}