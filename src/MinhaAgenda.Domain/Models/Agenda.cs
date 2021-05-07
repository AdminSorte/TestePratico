using System;

namespace MinhaAgenda.Domain.Models
{
    public class Agenda : Entity
    {
      
        public Agenda() { }

        public Agenda(string titulo, string descricao, DateTime dataAgedamento)
        { 
            Titulo = titulo;
            Descricao = descricao;
            DataAgedamento = dataAgedamento;
        }

        public Agenda(string titulo)
        {
            Titulo = titulo;
       
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataAgedamento { get; private set; }
    }
}
