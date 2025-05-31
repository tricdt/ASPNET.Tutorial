using Duende.IdentityServer;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        var idsvrBuilder = builder.Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes
                options.EmitStaticAudienceClaim = true;
                options.PushedAuthorization.AllowUnregisteredPushedRedirectUris = true;

                options.Preview.StrictClientAssertionAudienceValidation = true;
            })
            .AddTestUsers(TestUsers.Users);

        idsvrBuilder.AddInMemoryIdentityResources(Config.IdentityResources);
        idsvrBuilder.AddInMemoryApiScopes(Config.ApiScopes);
        idsvrBuilder.AddInMemoryApiResources(Config.ApiResources);
        idsvrBuilder.AddInMemoryClients(Config.Clients);

        // this is only needed for the JAR and JWT samples and adds supports for JWT-based client authentication
        idsvrBuilder.AddJwtBearerClientAuthentication();

        builder.Services.AddAuthentication()
          .AddOpenIdConnect("oidc", "Sign-in with demo.duendesoftware.com", options =>
          {
              options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
              options.SignOutScheme = IdentityServerConstants.SignoutScheme;
              options.SaveTokens = true;

              options.Authority = "https://demo.duendesoftware.com";
              options.ClientId = "interactive.confidential";
              options.ClientSecret = "secret";
              options.ResponseType = "code";

              options.TokenValidationParameters = new()
              {
                  NameClaimType = "name",
                  RoleClaimType = "role"
              };
          });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();

        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages();

        return app;
    }
}
