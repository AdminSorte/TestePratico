using Microsoft.EntityFrameworkCore;
using MinhaAgendaMinhaVida.Models;

namespace MinhaAgendaMinhaVida.Data
{
    public class Context : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,55065;Database=master;User Id=dba;Password=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfiguration());
        }
    }
}
