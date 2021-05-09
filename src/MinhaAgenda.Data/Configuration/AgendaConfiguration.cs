using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAgenda.Data.Configuration
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");


            builder.HasData(new Agenda("Sera se vou Passar?", "So deus Saber...", DateTime.Now) { Id = 1},
            new Agenda("Sorte Online", "hummmm", DateTime.Now) { Id = 2 },
             new Agenda("Sei não viu...", "hummmm", DateTime.Now) { Id = 3 },
            new Agenda("Então Beleza,Boa Segunda-Feira", "Vou Joga na mega Sena qualquer coisa...", DateTime.Now) { Id = 4});

   

        }
    }
}
