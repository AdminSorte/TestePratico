using System;

namespace RS.SorteOnline.Agenda.Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
