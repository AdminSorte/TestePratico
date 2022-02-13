using CalendarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Service
{
    public class UserService
    {
    }

    public interface IUserServiceInterface
    {
        TokenResponse CreateToken(AuthModel user);
        void CreateUser(UserCreate user);
        void DeleteUser(string email, string password);
        string GetEmailFromToken(string token);
        User GetUserFromToken(string token);
    }
}
