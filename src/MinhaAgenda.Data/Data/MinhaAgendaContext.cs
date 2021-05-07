using Microsoft.EntityFrameworkCore;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Data.Data
{
    public class MinhaAgendaContext : DbContext
    {
        public MinhaAgendaContext(DbContextOptions<MinhaAgendaContext> options) : base(options)
        {

        }

        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(250)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MinhaAgendaContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine);
        }

    }
}
