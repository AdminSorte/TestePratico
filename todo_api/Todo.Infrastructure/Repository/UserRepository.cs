using System.Threading.Tasks;
using Todo.Application.Repository;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> FindByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateAsync(User data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(User data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ChangePasswordAsync(User data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}