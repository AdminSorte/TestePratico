using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Application.Repository
{
    public interface IUserRepository
    {
        Task<User> FindById(int id);
        Task<User> FindByEmail(string email);
        Task<int> CreateAsync(User data);
        Task<bool> UpdateAsync(User data);
        Task<bool> ChangePasswordAsync(User data);
        Task<bool> RemoveAsync(int id);
    }
}