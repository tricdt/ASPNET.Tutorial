using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tedu.CoreApp.Data.EF.Extensions;
using Tedu.CoreApp.Data.Entities;

namespace Tedu.CoreApp.Data.EF.Configurations;

public class TagConfiguration : DbEntityConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> entity)
    {
        entity.Property(c => c.Id).HasMaxLength(50)
            .IsRequired().HasColumnType("varchar(50)");
    }
}