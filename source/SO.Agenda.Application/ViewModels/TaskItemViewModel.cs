using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SO.Agenda.Application.ViewModels
{
    public class TaskItemViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime? DateTime { get; set; }
    }
}
