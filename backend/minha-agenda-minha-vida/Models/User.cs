namespace minha_agenda_minha_vida.Models
{
    public class User
    {
        public User(int id, string name, string password, string token)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Token = token;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}