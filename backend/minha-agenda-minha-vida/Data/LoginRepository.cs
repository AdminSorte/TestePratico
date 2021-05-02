using System.Linq;
using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Data
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AgendaDbContext _context;
        public LoginRepository(AgendaDbContext context){
            _context = context;
        }
        public User MakeLogin(string name, string password)
        {
            IQueryable<User> query = _context.Users;
            query = query.Where (
                user => (user.Name ==name && user.Password == password)
            );

            return query.FirstOrDefault(); 
        }
    }
}