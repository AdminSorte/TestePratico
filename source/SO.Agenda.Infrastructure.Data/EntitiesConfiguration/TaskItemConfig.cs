using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO.Agenda.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Agenda.Infrastructure.Data.EntitiesConfiguration
{
    public class TaskItemConfig : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
