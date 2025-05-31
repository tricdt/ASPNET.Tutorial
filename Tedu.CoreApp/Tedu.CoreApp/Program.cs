using Serilog;
using Tedu.CoreApp;
using Tedu.CoreApp.StartupExtensions;
using TeduCore.Data.EF;


// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var host = CreateHostBuilder(args).Build();
//         using (var scope = host.Services.CreateScope())
//         {
//             var services = scope.ServiceProvider;
//             try
//             {
//                 var dbInitializer = services.GetService<DbInitializer>();
//                 dbInitializer.Seed().Wait();
//             }
//             catch (Exception ex)
//             {
//                 var logger = services.GetRequiredService<ILogger<Program>>();
//                 logger.LogError(ex, "An error occurred while seeding the database.");
//             }
//         }

//         host.Run();
//     }

//     public static IHostBuilder CreateHostBuilder(string[] args) =>
//       Host.CreateDefaultBuilder(args)
//           .ConfigureWebHostDefaults(webBuilder =>
//           {
//               webBuilder.UseStartup<Startup>();
//           });
// }



Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .WriteTo.File("Logs/tedu-.txt", rollingInterval: RollingInterval.Day)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddCustomizedSwagger(builder.Environment);

    var app = builder.ConfigureServices()
        .ConfigurePipeline();   
    //app.UseCustomizedSwagger(builder.Environment);



    // using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    // {
    //     var services = scope.ServiceProvider;
    //     try
    //     {
    //         Log.Information("Seeding data...");
    //         var dbInitializer = services.GetRequiredService<DbInitializer>();
    //         await dbInitializer.Seed();
    //         Log.Information("Done seeding data.");
    //     }
    //     catch (Exception ex)
    //     {
    //         Log.Fatal(ex, "An error occurred while seeding the database.");
    //         throw;
    //     }
    // }
    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}