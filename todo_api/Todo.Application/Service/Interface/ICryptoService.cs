namespace Todo.Application.Service.Interface
{
    public interface ICryptoService
    {
         string HashPassword(string password);
         bool CompareHash(string attemptedPassword, string password);
    }
}