using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tedu.CoreApp.Data.EF.Extensions;
using Tedu.CoreApp.Data.Entities;
using Tedu.CoreApp.Data.Entities.System;

namespace Tedu.CoreApp.Data.EF.Configurations;
public class SystemConfigConfiguration : DbEntityConfiguration<Setting>
{
    public override void Configure(EntityTypeBuilder<Setting> entity)
    {
        entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        // etc.
    }
}
