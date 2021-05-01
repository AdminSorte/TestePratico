using System;

namespace minha_agenda_minha_vida.Models
{
    public class Agenda
    {
        public Agenda(int id, string titulo, string descricao, DateTime data)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Data = data;

        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}