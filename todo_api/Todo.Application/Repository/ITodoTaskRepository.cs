using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Application.Repository
{
    public interface ITodoTaskRepository
    {
        Task<TodoTask> GetById(int id);
        Task<List<TodoTask>> GetAllAsync(int userId);
        Task<int> CreateAsync(TodoTask data);
        Task<bool> UpdateAsync(TodoTask data);
        Task<bool> RemoveAsync(int id);
    }
}