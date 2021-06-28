using System;

namespace Todo.Application.Dto.TodoTask
{
    public class CreateTodoTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTodo { get; set; }
    }
}