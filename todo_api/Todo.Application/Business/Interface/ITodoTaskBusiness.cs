using System.Threading.Tasks;
using Todo.Application.Dto.TodoTask;
using Todo.Application.Response;

namespace Todo.Application.Business.Interface
{
    public interface ITodoTaskBusiness
    {
         Task<ResponseService> GetAllAsync();
        Task<ResponseService> CreateAsync(CreateTodoTaskDto data);
        Task<ResponseService> UpdateAsync(UpdateTodoTaskDto data);
        Task<ResponseService> RemoveAsync(int id);
    }
}