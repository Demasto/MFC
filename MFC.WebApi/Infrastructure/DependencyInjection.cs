using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // string? connectionsStr = Environment.GetEnvironmentVariable("DATABASE_CONNECT");
        //
        // if (connectionsStr == null)
        //     throw new NullReferenceException("connectionsStr is null");

        services.AddDbContext<MfcContext>();
        // services.AddDbContext<MfcContext>(options =>
        //     options.UseNpgsql(connectionsStr));
        
        services.AddTransient<IStatementRepository, StatementRepository>();
        services.AddTransient<ISchemaRepository, SchemaRepository>();
        
        
        return services;
    }
    
    
}