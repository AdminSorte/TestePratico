namespace Todo.Domain.Entities
{
    public class TodoTask : Core.Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}