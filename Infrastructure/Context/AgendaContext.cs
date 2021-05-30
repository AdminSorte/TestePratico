using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext() { }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { }
        
        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AAJ6U28\SQLEXPRESS;Initial Catalog=SorteOnline_DB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AgendaMap());
        }


    }
}
