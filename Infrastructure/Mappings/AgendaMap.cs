using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Titulo")
                .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.Descricao)
                .HasMaxLength(200)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR(200)");

            builder.Property(x => x.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");
        }
    }
}
