using Microsoft.EntityFrameworkCore;
using RS.SorteOnline.Agenda.Domain.Models;
using RS.SorteOnline.Agenda.Infra.Data.Mapping;


namespace RS.SorteOnline.Agenda.Infra.Data.Context
{
    public class RSContext : DbContext
    {
        public RSContext(DbContextOptions<RSContext> options) : base(options) { }

        public DbSet<AgendaModel> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
