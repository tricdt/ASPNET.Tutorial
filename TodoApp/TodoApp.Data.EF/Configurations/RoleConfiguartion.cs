using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Data.Entities;
using TodoApp.Data.EF.Extensions;

namespace TodoApp.Data.EF.Configurations;

public class RoleConfiguartion : DbEntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> entity)
    {
        entity.Property<string>(e => e.Description).HasMaxLength(250).IsRequired();
    }
}
