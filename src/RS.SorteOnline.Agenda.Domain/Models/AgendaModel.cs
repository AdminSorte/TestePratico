using System;
using System.Collections.Generic;
using System.Text;

namespace RS.SorteOnline.Agenda.Domain.Models
{
    public class AgendaModel : BaseEntity
    {
        public AgendaModel(int id, string titulo, string descricao, DateTime dtInicio, DateTime dtFim, bool todoDia)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataInicio = dtInicio;
            DataFim = dtFim;
            TodoDia = todoDia;
        }

        protected AgendaModel() { }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool TodoDia { get; set; }

    }
}

