using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tedu.CoreApp.Data.EF.Extensions;
using Tedu.CoreApp.Data.Entities;

namespace Tedu.CoreApp.Data.EF.Configurations;
public class ProductTagConfiguration : DbEntityConfiguration<ProductTag>
{
    public override void Configure(EntityTypeBuilder<ProductTag> entity)
    {
        entity.Property(c => c.TagId).HasMaxLength(255).IsRequired()
        .HasColumnType("varchar(255)");
        // etc.
    }
}
