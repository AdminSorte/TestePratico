using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Domain.Model.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title;
        public string Description;
        public DateTime DateTime;
    }
}
