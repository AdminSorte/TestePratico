using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Application.Dto;

namespace Todo.Application.Business.Interface
{
    public interface ITodoTaskBusiness
    {
         Task<List<TodoTaskDto>> GetAllAsync(int userId);
        Task<int> CreateAsync(TodoTaskDto data);
        Task<bool> UpdateAsync(TodoTaskDto data);
        Task<bool> RemoveAsync(int id);
    }
}