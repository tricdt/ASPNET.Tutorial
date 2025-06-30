using System;
using Examination.API.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Examination.API.Extensions;

public static class HostingExtension
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        });
        builder.Services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examination.API V1", Version = "v1" });
            c.SwaggerDoc("v2", new OpenApiInfo { Title = "Examination.API V2", Version = "v2" });

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri($"{builder.Configuration.GetValue<string>("IdentityUrl")}/connect/authorize"),
                        TokenUrl = new Uri($"{builder.Configuration.GetValue<string>("IdentityUrl")}/connect/token"),
                        Scopes = new Dictionary<string, string>()
                        {
                            {"full_access", "full_access" }
                        },

                    }
                }
            });
            //c.OperationFilter<AuthorizeCheckOperationFilter>();

        });
        var identityUrl = builder.Configuration.GetValue<string>("IdentityUrl");
        // builder.Services.AddAuthentication(options =>
        // {
        //     options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults
        //         .AuthenticationScheme;
        //     options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults
        //         .AuthenticationScheme;
        // }).AddJwtBearer(options =>
        // {
        //     options.Authority = identityUrl;
        //     options.RequireHttpsMetadata = false;
        //     options.Audience = "exam_api";
        //     options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        //     {
        //         ValidateIssuerSigningKey = true,
        //         ValidateIssuer = false,
        //         ValidateAudience = false
        //     };
        //     //Fix SSL
        //     options.BackchannelHttpHandler = new HttpClientHandler
        //     {
        //         ServerCertificateCustomValidationCallback = delegate { return true; }
        //     };
        // });
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("exam_api_swaggerui");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examination.API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Examination.API V2");
                c.OAuth2RedirectUrl("https://localhost:5001/swagger/oauth2-redirect.html");
            });
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }
        app.UseSerilogRequestLogging();
        app.UseAuthentication();
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.UseRouting();
        app.MapControllers();
        return app;
    }
}
