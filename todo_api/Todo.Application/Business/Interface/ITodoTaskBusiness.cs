using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Application.Dto;
using Todo.Application.Response;

namespace Todo.Application.Business.Interface
{
    public interface ITodoTaskBusiness
    {
         Task<ResponseService> GetAllAsync(int userId);
        Task<ResponseService> CreateAsync(TodoTaskDto data);
        Task<ResponseService> UpdateAsync(TodoTaskDto data);
        Task<ResponseService> RemoveAsync(int id);
    }
}