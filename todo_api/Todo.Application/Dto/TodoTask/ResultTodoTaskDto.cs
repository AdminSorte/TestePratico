using System;

namespace Todo.Application.Dto.TodoTask
{
    public class ResultTodoTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTodo { get; set; }
    }
}