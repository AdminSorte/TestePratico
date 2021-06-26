using System;

namespace MinhaAgendaMinhaVida.Domain.Model
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}