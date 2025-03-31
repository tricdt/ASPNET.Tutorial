using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tedu.CoreApp.Data.EF.Extensions;
using Tedu.CoreApp.Data.Entities;

namespace Tedu.CoreApp.Data.EF.Configurations;

public class AdvertistmentPositionConfiguration : DbEntityConfiguration<AdvertistmentPosition>
{
    public override void Configure(EntityTypeBuilder<AdvertistmentPosition> entity)
    {
        entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        // etc.
    }
}
