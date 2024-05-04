using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Student = Infrastructure.Identity;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
  
        services.AddDbContext<MfcContext>();
        
        services.AddScoped<IStatementRepository, StatementRepository>();
        services.AddScoped<ISchemaRepository, SchemaRepository>();
        
        
        return services;
    }
    
    
}