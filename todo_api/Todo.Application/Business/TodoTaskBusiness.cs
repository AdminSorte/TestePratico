using System.Threading.Tasks;
using Todo.Application.Business.Interface;
using Todo.Application.Dto.TodoTask;
using Todo.Application.Response;

namespace Todo.Application.Business
{
    public class TodoTaskBusiness : ITodoTaskBusiness
    {
        public async Task<ResponseService> GetAllAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> CreateAsync(TodoTaskDto data)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> UpdateAsync(TodoTaskDto data)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}