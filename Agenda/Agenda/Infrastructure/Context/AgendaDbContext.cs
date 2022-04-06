using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Agenda.Infrastructure.Context
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
        : base(options)
        {
        }


        public DbSet<Agenda.Models.Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Agenda.Models.Agenda>(option =>
                option.ToTable("Agenda").HasKey(x=>x.Id)
            );
        }
    }
}
