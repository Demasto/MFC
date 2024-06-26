using WebApi.Services;
using WebApi.Services.Interfaces;

using WebApi.Configurations;

namespace WebApi;

public static class WebApiDI
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();
        services.AddTransient<ITaskService, TaskService>();
        services.AddTransient<IEmailService, EmailService>();
        
        services.AddIdentity();

        return services;
    }
    
    public static IServiceCollection AddWebConfigurations(this IServiceCollection services)
    {
        services.AddCookie();
        services.AddMyCors(PolicyName);
        
        return services;
    }
    
     public const string PolicyName = "_myAllowSpecificOrigins";
    
}