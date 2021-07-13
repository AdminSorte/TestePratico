using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestePratico.Web.Models
{
    public class Agenda
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
    }
}