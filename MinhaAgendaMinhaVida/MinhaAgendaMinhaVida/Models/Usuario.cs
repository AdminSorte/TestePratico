namespace MinhaAgendaMinhaVida.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
