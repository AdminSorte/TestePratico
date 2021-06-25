namespace Todo.Domain.Entities
{
    public class Task : Core.Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}