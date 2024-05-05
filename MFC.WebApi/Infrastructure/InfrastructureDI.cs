using Infrastructure.Data;

using Microsoft.Extensions.DependencyInjection;
using Student = Infrastructure.Identity;

namespace Infrastructure;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<MfcContext>();
        return services;
    }
    
}