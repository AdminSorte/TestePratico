using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public IConfiguration Configuration { get; }
        public AgendaContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"))
                .EnableDetailedErrors(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskItemConfig());

        }
    }
}
