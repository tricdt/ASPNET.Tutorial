using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Data.EF.Extensions;
using TodoApp.Data.Entities;

namespace TodoApp.Data.EF.Configurations;

public class UserConfiguration : DbEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> entity)
    {
        entity.Property<string>(e => e.FirstName).HasMaxLength(250).IsRequired();
        entity.Property<string>(e => e.LastName).HasMaxLength(250).IsRequired();
    }
}
