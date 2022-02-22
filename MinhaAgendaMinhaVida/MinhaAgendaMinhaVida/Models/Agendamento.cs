namespace MinhaAgendaMinhaVida.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
