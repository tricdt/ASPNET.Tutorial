using PortalApp.Extensions;
using Serilog;

string appName = typeof(Program).Assembly.GetName().Name ?? "Tedu.Exam.WebApps.PortalApp";
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
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

Log.Information("Starting up");

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
    app.MapGet("/", () => "Welcome to Tedu.Exam.WebApp.PortalApp Razor page!").RequireAuthorization();
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