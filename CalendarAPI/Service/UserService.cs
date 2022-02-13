using CalendarAPI.BD;
using CalendarAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAPI.Service
{
    public class UserService : IUserServiceInterface
    {

        private UserDB _db;
        private readonly string key;
        public UserService(UserDB db, IConfiguration config)
        {
            this._db = db;
            this.key = config["AuthKey"];


        }

        public TokenResponse CreateToken(AuthModel user)
        {
            var userDB = this._db.users.Where(x => x.email == user.email).FirstOrDefault();
            if (userDB is null)
            {
                throw new Exception("User not found");
            }
            using (var md5 = MD5.Create())
            {
                //var hash = GetMd5Hash(md5.ComputeHash(Encoding.UTF8.GetBytes(credencials.password.ToString())));
                if (userDB.password == user.password)
                {
                    var key = Encoding.ASCII.GetBytes(this.key);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var descriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]{
                              new Claim("name",userDB.username),
                              new Claim("email", userDB.email)
                          }),
                        Expires = DateTime.UtcNow.AddHours(72.0),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(descriptor);
                    return new TokenResponse(tokenHandler.WriteToken(token));
                }
            }
            throw new Exception("Password wrong");
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
