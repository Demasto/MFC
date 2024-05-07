using Infrastructure.Data;
using Infrastructure.Repo;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddDbContext<MfcContext>();
        return services;
    }
    
}