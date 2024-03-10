using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        
        services.AddDbContext<MfcContext>(options =>
            options.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECT")));
        
        services.AddTransient<IStatementRepository, StatementRepository>();
        
        
        return services;
    }
}