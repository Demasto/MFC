using Microsoft.AspNetCore.Identity;

using Domain.Entities.Users;
using Infrastructure.Data;


namespace WebApi.Configurations;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        
        services.
            AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

            })
            .AddEntityFrameworkStores<MfcContext>()
            .AddDefaultTokenProviders();
        
        services
            .AddIdentityCore<StudentUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<MfcContext>();
        
        services
            .AddIdentityCore<EmployeeUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<MfcContext>();
        

        return services;
    }
}