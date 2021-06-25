using System.Threading.Tasks;
using Todo.Application.Dto;

namespace Todo.Application.Business.Interface
{
    public interface IUserBusiness
    {
        Task<UserDto> Login(UserDto data);
        Task<int> CreateAsync(UserDto data);
        Task<bool> UpdateAsync(UserDto data);
        Task<bool> ChangePasswordAsync(UserDto data);
        Task<bool> RemoveAsync(int id);
    }
}