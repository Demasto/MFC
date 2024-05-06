namespace WebApi.Configurations;

public static class CorsPolicyConfiguration
{
    public static IServiceCollection AddMyCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: policyName,
                policy  =>
                {
                    policy.WithOrigins("https://localhost:7149", "http://localhost:8080", "https://localhost:3000", "http://localhost:3000") 
                        .AllowAnyHeader()  
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });

        return services;
    }
}