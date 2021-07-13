using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestePratico.API.Models
{
    public class AgendaDTO
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}