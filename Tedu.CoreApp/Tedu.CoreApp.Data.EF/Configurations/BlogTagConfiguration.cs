using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tedu.CoreApp.Data.EF.Extensions;
using Tedu.CoreApp.Data.Entities;

namespace Tedu.CoreApp.Data.EF.Configurations;

public class BlogTagConfiguration : DbEntityConfiguration<PostTag>
{
    public override void Configure(EntityTypeBuilder<PostTag> entity)
    {
        entity.Property(c => c.TagId).HasMaxLength(255).IsRequired()
        .HasColumnType("varchar(255)");
        // etc.
    }
}
