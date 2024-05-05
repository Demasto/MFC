using WebApi.Middleware;

namespace WebApi.Configurations;

public static class SwaggerConfiguration
{
    public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
    {
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseMiddleware<RedirectToSwaggerMiddleware>();
        return app;
    }
}