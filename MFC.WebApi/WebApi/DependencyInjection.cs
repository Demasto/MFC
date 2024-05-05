using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Identity;

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
        
        
        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = Environment.GetEnvironmentVariable("COOKIE_NANE") ?? "MFC.WebApi";
            config.Cookie.SameSite = SameSiteMode.None;
            config.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            config.LoginPath = "/api/account/login";
            config.LogoutPath = "/api/account/logout";
        });
        

        return services;
    }
    
    public static IServiceCollection AddMyCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: policyName,
                policy  =>
                {
                    policy.WithOrigins("https://localhost:7149", "http://localhost:8080", "https://localhost:3000", "http://localhost:3000") 
                        .AllowAnyHeader()  
                        .AllowAnyMethod();
                });
        });

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