using Microsoft.EntityFrameworkCore;
using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Infrastructure.Data.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Infrastructure.Data.Context
{
    public class AgendaContext : DbContext
    {
        public DbSet<TaskItem> TaskItem { get; set; }


        public AgendaContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=sqlexpress01;Database=so_agenda;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskItemConfig());

        }
    }
}
