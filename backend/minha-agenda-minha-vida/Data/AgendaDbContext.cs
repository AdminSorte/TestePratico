using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using minha_agenda_minha_vida.Models;

namespace minha_agenda_minha_vida.Data
{
    public class AgendaDbContext: DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Agenda>().HasData(new List<Agenda>(){
                new Agenda(id: 1, titulo: "Reunião", descricao: "Reuniao com a Marilene", data: new DateTime(2020,10,20)),
                new Agenda(id: 2, titulo: "Reunião", descricao: "Reuniao com a Julia", data: new DateTime(2020,10,20)),
                new Agenda(id: 3, titulo: "Reunião", descricao: "Reuniao com a Thais", data: new DateTime(2020,10,20))
            });
        }
    }
}