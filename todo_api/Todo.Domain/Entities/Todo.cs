namespace Todo.Domain.Entities
{
    public class Todo : Core.Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}