using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sala.TodoApp.Data.Entities;

namespace Sala.TodoApp.Data.EF.Configurations;

public class TodoConfiguration : DbEntityConfiguration<Todo>
{
    public override void Configure(EntityTypeBuilder<Todo> entity)
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Name).HasMaxLength(250).IsRequired();
    }
}
