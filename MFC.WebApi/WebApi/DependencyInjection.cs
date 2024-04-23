using WebApi.Middleware;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {

        services.AddTransient<IStatementService, StatementService>();

        
        return services;
    }
    
    public static IApplicationBuilder AddSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseMiddleware<RedirectToSwaggerMiddleware>();
        return app;
    }
    
}