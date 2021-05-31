using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RS.SorteOnline.Agenda.Domain.Models;

namespace RS.SorteOnline.Agenda.Infra.Data.Mapping
{
    public class AgendaMap : IEntityTypeConfiguration<AgendaModel>
    {
        public void Configure(EntityTypeBuilder<AgendaModel> builder)
        {
            builder.ToTable("Agenda");

            builder.HasKey(c => c.Id);

            builder.Property(a => a.Titulo)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Titulo");

            builder.Property(a => a.Descricao)
                .IsRequired()
                .HasColumnName("Descricao");

            builder.Property(a => a.DataInicio)
                .IsRequired()
                .HasColumnName("DT_Inicio");

            builder.Property(a => a.DataFim)
                .HasColumnName("DT_Fim");

            builder.Property(a => a.TodoDia)
                .IsRequired()
                .HasColumnName("Todo_Dia");
        }
    }
}
