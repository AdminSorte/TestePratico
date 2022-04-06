using Agenda.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<AgendaUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AgendaUser>
{
    public void Configure(EntityTypeBuilder<AgendaUser> builder)
    {
        //builder.Property(x => x.FirstName).HasMaxLength(100);
        //builder.Property(x => x.LastName).HasMaxLength(100);
    }
}