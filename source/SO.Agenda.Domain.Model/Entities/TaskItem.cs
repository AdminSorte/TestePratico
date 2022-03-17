using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Domain.Model.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
