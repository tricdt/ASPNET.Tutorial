using System;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Extensions;

public static class DbContextExtensions
{
    public static async Task SeedDataAsync<TContext>(this IServiceProvider serviceProvider,
           Func<TContext, Task> seedAction) where TContext : DbContext
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<TContext>();

            await context.Database.MigrateAsync();

            await seedAction(context);

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }
    public static async Task SeedDataAsync<TContext, TSeeder>(this IServiceProvider serviceProvider)
        where TContext : DbContext
        where TSeeder : IDataSeeder<TContext>
    {
        await serviceProvider.SeedDataAsync<TContext>(async context =>
        {
            var seeder = ActivatorUtilities.CreateInstance<TSeeder>(serviceProvider);
            await seeder.SeedAsync(context);
        });
    }
}

public interface IDataSeeder<TContext> where TContext : DbContext
{
    Task SeedAsync(TContext context);
}