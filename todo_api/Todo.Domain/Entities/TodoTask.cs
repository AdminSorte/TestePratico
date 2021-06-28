using System;

namespace Todo.Domain.Entities
{
    public class TodoTask : Core.Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTodo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}