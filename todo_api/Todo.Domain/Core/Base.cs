using System;

namespace Todo.Domain.Core
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}