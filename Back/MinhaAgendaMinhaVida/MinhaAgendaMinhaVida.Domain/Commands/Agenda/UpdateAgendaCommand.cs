using System;

namespace MinhaAgendaMinhaVida.Domain.Commands.Agenda
{
    public class UpdateAgendaCommand
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}