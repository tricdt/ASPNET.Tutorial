using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XTLab.MvcApp.Data.EF.Extensions;
using XTLab.MvcApp.Data.Entities;

namespace XTLab.MvcApp.Data.EF.Configurations;

public class ContactConfiguration : DbEntityConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> entity)
    {
        entity.HasKey(e => e.Id);
    }
}
