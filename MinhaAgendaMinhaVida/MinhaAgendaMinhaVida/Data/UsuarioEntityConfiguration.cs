using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAgendaMinhaVida.Models;

namespace MinhaAgendaMinhaVida.Data
{
    public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsUnicode(false)
                ;

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsUnicode(false)
                ;

            builder.HasIndex(x => x.Login)
                .IsUnique();

            builder.HasMany(usu => usu.Agendamentos)
                .WithOne(agend => agend.Usuario)
                .HasConstraintName("FK_Usuario_Agend")
                .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(x => x.Token);
        }
    }
}
