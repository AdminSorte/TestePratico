using System;
using System.Security.Cryptography;
using System.Text;
using Todo.Application.Service.Interface;

namespace Todo.Application.Service
{
    public class CryptoService : ICryptoService
    {
        private readonly string salt = "_TODO_API_";
        
        public string HashPassword(string password)
        {
            SHA256Managed sha256 = new SHA256Managed();

            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(salt, password));
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return Convert.ToBase64String(hashedBytes);
        }

        public bool CompareHash(string attemptedPassword, string password)
        {
            string base64AttemptedHash = HashPassword(attemptedPassword);
            return password == base64AttemptedHash;
        }
    }
}