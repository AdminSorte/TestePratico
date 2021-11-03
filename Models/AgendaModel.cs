using System;

namespace TestePratico.Models
{
  public class AgendaModel
  {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
  }
}