namespace Todo.Domain.Entities
{
    public class User : Core.Base
    {
        public User()
        { }

        public User(int id)
        {
            this.Id = id;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}