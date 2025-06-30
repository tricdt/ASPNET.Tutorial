using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using PortalApp.Core;
using Serilog;

namespace PortalApp.Extensions;

public static class HostingExtension
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddRazorPages();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = AuthenticationConsts.SignInScheme;
            options.DefaultChallengeScheme = AuthenticationConsts.OidcAuthenticationScheme;
        })
        .AddCookie(AuthenticationConsts.SignInScheme, options =>
        {
            options.Cookie.Name = builder.Configuration["IdentityServerConfig:CookieName"];
            options.LoginPath = UrlConstants.Login;
            options.LogoutPath = UrlConstants.Login;
            options.Events = new CookieAuthenticationEvents()
            {
                OnValidatePrincipal = context =>
                {
                    if (context.Properties.Items.ContainsKey(".Token.expires_at"))
                    {
                        var expire = DateTime.Parse(context.Properties.Items[".Token.expires_at"]);
                        if (expire < DateTime.Now)
                        {
                            context.ShouldRenew = true;
                            context.RejectPrincipal();
                        }
                    }
                    return Task.FromResult(0);
                }
            };
        })
        .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
        {
            options.Authority = builder.Configuration["IdentityServerConfig:IdentityServerUrl"];
            options.ClientId = builder.Configuration["IdentityServerConfig:ClientId"];
            options.ClientSecret = builder.Configuration["IdentityServerConfig:ClientSecret"];
            options.ResponseType = "code";
            options.RequireHttpsMetadata = false;
            options.SaveTokens = true;
            //Fix bypass SSL connection validate
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            options.BackchannelHttpHandler = handler;
            options.CallbackPath = "/authentication/login-callback";
            options.Events = new OpenIdConnectEvents
            {
                OnRedirectToIdentityProvider = context =>
                {
                    return Task.CompletedTask;
                },
            };
        });
        return builder.Build();
    }
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapRazorPages();
        return app;
    }
}
