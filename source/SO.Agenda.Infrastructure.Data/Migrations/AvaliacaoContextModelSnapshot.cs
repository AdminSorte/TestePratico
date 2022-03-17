using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SO.Agenda.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AgendaContext))]
    partial class AvaliacaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true);
            modelBuilder.Entity("SO.Agenda.Domain.Model.Entities.TaskItem", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Title");

                b.Property<string>("Description");

                b.Property<DateTime>("DateTime");

                b.HasKey("Id");

                b.ToTable("TaskItem");
            });

#pragma warning restore 612, 618
        }
    }
}
