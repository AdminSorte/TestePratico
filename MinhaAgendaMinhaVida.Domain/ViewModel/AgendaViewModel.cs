using System;

namespace MinhaAgendaMinhaVida.Domain.ViewModel
{
    public class AgendaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}