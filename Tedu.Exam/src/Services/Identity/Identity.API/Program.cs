using System.Globalization;
using System.Text;
using Identity.API;
using Identity.API.Database;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;


string appName = typeof(Program).Namespace;
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{CultureInfo.CurrentCulture.Name}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("ApplicationContext", appName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .WriteTo.File("logs/Tedu.Exam.log", rollingInterval: RollingInterval.Day,
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));
    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();
    app.MigrateDbContext<PersistedGrantDbContext>((_, _) => { })
        .MigrateDbContext<ApplicationDbContext>((context, services) =>
        {
            var env = services.GetService<IWebHostEnvironment>();
            var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();
            var settings = services.GetService<IOptions<AppSettings>>();

            new ApplicationDbContextSeed()
                .SeedAsync(context, env, logger, settings)
                .Wait();
        })
        .MigrateDbContext<ConfigurationDbContext>((context, services) =>
        {
            new ConfigurationDbContextSeed()
                .SeedAsync(context, configuration)
                .Wait();
        });

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
