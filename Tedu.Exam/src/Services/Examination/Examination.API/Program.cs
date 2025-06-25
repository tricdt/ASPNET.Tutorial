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
    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
