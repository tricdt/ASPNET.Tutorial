using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sala.TodoApp.Data.EF;

public static class ModelBuilderExtension
{
    public static void AddConfiguration<TEntity>(this ModelBuilder builder, DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
    {
        builder.Entity<TEntity>(entityConfiguration.Configure);
    }


}
public abstract class DbEntityConfiguration<TEntity> where TEntity : class
{
    public abstract void Configure(EntityTypeBuilder<TEntity> entity);
}