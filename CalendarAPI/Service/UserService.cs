using CalendarAPI.BD;
using CalendarAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarAPI.Service
{
    public class UserService : IUserServiceInterface
    {

        private UserDB _db;
        public UserService(UserDB db)
        {
            this._db = db;
          
        }

        public TokenResponse CreateToken(AuthModel user)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(UserCreate user)
        {
            var userDB = new User();
            userDB.email = user.email;
            userDB.password = user.password;
            userDB.username = user.username;
            userDB.dateCreated = DateTime.Now;
            this._db.users.Add(userDB);
            this._db.SaveChanges();
        }

        public void DeleteUser(string email, string password)
        {
            var userDB = this._db.users.Where(x => (x.email == email) & (x.password == password)).FirstOrDefault();
            if (userDB is null)
            {
                throw new Exception("User don't find");
            }
            this._db.Remove(userDB);
            this._db.SaveChanges();
        }

        public string GetEmailFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public User GetUserFromToken(string token)
        {
            throw new NotImplementedException();
        }
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
