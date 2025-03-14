using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Data.Entities;
using static TodoApp.Data.EF.Extensions.ModelBuilderExtension;

namespace TodoApp.Data.EF.Configurations;

public class TodoConfiguration : DbEntityConfiguration<Todo>
{
    public override void Configure(EntityTypeBuilder<Todo> entity)
    {
        entity.HasKey(e =>e.Id);
    }
}
