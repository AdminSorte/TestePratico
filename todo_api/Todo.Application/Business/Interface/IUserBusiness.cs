using System.Threading.Tasks;
using Todo.Application.Dto.User;
using Todo.Application.Response;

namespace Todo.Application.Business.Interface
{
    public interface IUserBusiness
    {
        Task<ResponseService> Login(LoginDto data);
        Task<ResponseService> CreateAsync(CreateUserDto data);
        Task<ResponseService> UpdateAsync(UpdateUserDto data);
        Task<ResponseService> ChangePasswordAsync(ChangePasswordDto data);
        Task<ResponseService> RemoveAsync();
    }
}