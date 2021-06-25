using System.Threading.Tasks;
using Todo.Application.Dto;
using Todo.Application.Response;

namespace Todo.Application.Business.Interface
{
    public interface IUserBusiness
    {
        Task<ResponseService> Login(UserDto data);
        Task<ResponseService> CreateAsync(UserDto data);
        Task<ResponseService> UpdateAsync(UserDto data);
        Task<ResponseService> ChangePasswordAsync(UserDto data);
        Task<ResponseService> RemoveAsync(int id);
    }
}