using System.Globalization;
using Examination.API.Extensions;
using Serilog;

string appName = typeof(Program).Assembly.GetName().Name ?? "Tedu.Exam.Examination.API";
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
                .WriteTo.File("logs/Tedu.Exam.log", rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
try
{
    Log.Information("Starting web host ({ApplicationContext})...", appName);
    var builder = WebApplication.CreateBuilder(args);
    builder.WebHost.CaptureStartupErrors(true);
    builder.WebHost.UseIISIntegration();
    builder.Host.UseSerilog();

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    //Seed the database or perform any startup tasks
    Log.Information("Seeding database...");
    using (var scope = app.Services.CreateScope())
    {
        //await scope.ServiceProvider.SeedDataAsync<AppDbContext, UserSeedData>();
    }
    app.MapGet("/", () => "Welcome to Tedu.Exam.Examination API!");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup failed");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
