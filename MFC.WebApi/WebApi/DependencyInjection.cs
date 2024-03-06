using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {

        services.AddTransient<IFileService, FileService>();

        
        return services;
    }
}