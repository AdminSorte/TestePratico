using System.Threading.Tasks;
using Todo.Application.Business.Interface;
using Todo.Application.Dto;
using Todo.Application.Response;

namespace Todo.Application.Business
{
    public class UserBusiness : IUserBusiness
    {
        public async Task<ResponseService> Login(UserDto data)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> CreateAsync(UserDto data)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> ChangePasswordAsync(UserDto data)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> UpdateAsync(UserDto data)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseService> RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}