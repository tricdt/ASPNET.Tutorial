using System;
using System.Reflection;
using Identity.API.Database;
using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.OpenApi.Models;
using Polly;
using Microsoft.Data.SqlClient;
namespace Identity.API;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(migrationsAssembly);
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            }));
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<AppSettings>(builder.Configuration);

        builder.Services.AddIdentityServer(x =>
            {
                x.IssuerUri = "https://tedu.com.vn";
                x.Authentication.CookieLifetime = TimeSpan.FromHours(2);
            })
            .AddDeveloperSigningCredential()
            .AddAspNetIdentity<ApplicationUser>()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(migrationsAssembly);
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(migrationsAssembly);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Identity API",
                Version = "v1",
                Description = "A simple API for managing Identity services",
            });
        });
        builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API v1"));
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseCors("CorsPolicy");

        app.MapControllers();

        return app;
    }

    public static WebApplication MigrateDbContext<TContext>(this WebApplication host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                var retries = 10;
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                        retryCount: retries,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, timeSpan, retry, ctx) =>
                        {
                            logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", nameof(TContext), exception.GetType().Name, exception.Message, retry, retries);
                        });

                retry.Execute(() => InvokeSeeder(seeder, context, services));

                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);
            }
        }

        return host;
    }

    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
        where TContext : DbContext
    {
        context.Database.Migrate();
        seeder(context, services);
    }

}
