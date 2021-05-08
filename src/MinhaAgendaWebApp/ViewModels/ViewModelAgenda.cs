using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgendaWebApp.ViewModels
{
    public class ViewModelAgenda
    {
        public int Id { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Data Compromisso")]
        public DateTime DataAgedamento { get; set; }
    }
}
