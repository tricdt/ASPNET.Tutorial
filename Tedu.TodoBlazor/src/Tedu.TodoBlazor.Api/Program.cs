using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Tedu.TodoBlazor.Api;
using Tedu.TodoBlazor.Api.Data;
Console.WriteLine(args);
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .WriteTo.File("logs/ddd.aspnetcore.log", rollingInterval: RollingInterval.Day,
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration));
var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

if (!args.Contains("/seed"))
{
    Log.Information("Seeding database...");
    await TodoListDbContextSeed.SeedAsync(app);
    Log.Information("Done seeding database. Exiting.");
    return;
}

app.Run();
