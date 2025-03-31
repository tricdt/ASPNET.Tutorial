using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tedu.CoreApp.Data.EF.Extensions;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Data.Entities.System;

namespace TeduCoreApp.Data.EF.Configurations;
public class FunctionConfiguration : DbEntityConfiguration<Function>
{
    public override void Configure(EntityTypeBuilder<Function> entity)
    {
        entity.HasKey(c => c.Id);
        entity.Property(c => c.Id).IsRequired()
        .HasColumnType("varchar(128)");
        // etc.
    }
}
