using System;

namespace Tedu.CoreApp.StartupExtensions;

public static class ErrorHandlingExtension
{
    public static IApplicationBuilder UseCustomizedErrorHandling(this IApplicationBuilder app)
    {
        app.UseDeveloperExceptionPage();

        return app;
    }
}
