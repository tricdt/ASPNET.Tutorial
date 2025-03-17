using TodoApp.Data.EF;
using TodoApp.Extensions;

namespace TodoApp;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.MigrateDbContext<AppDbContext>((context, services) =>
        {
            var logger = services.GetService<ILogger<DbInitializer>>();
            new DbInitializer().SeedAsync(context, logger).Wait();
        });
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
          });
}
