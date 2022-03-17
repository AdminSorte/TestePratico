using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Application.ViewModels
{
    public class TaskItemFiltro
    {
        public string Title { get; set; }
        public IEnumerable<TaskItemViewModel> TaskItens { get; set; }    
    }
}
