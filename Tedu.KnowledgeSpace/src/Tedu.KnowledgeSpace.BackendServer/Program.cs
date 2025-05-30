using Serilog;
using Tedu.KnowledgeSpace.BackendServer;
using Tedu.KnowledgeSpace.BackendServer.Data;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();


    using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            Log.Information("Seeding data...");
            var dbInitializer = services.GetRequiredService<DbInitializer>();
            await dbInitializer.Seed();
            Log.Information("Done seeding data.");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
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