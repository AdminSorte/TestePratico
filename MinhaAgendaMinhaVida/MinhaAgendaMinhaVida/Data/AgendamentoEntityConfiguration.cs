using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAgendaMinhaVida.Models;

namespace MinhaAgendaMinhaVida.Data
{
    public class AgendamentoEntityConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsUnicode(false)
                ;

            builder.Property(t => t.Data)
                .HasColumnName("Data")
                .IsRequired();

            builder.HasOne(agend => agend.Usuario)
                .WithMany(usu => usu.Agendamentos)
                .HasConstraintName("FK_Agend_Usuario")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
