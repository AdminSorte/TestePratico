using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAgenda.API.ViewModel
{
    public class AgendaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get;  set; }
        public string Descricao { get;  set; }
        public DateTime DataAgedamento { get;  set; }
    }
}
