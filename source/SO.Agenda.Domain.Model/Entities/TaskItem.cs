using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Domain.Model.Entities
{
    public class TaskItem : BaseEntity
    {
        public Guid id;
        public string title;
        public string description;
        public DateTime dateTime;
        public bool done;
    }
}
