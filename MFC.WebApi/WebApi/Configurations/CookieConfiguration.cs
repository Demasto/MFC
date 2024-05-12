using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApi.Configurations;

public static class CookieConfiguration
{
    public static IServiceCollection AddCookie(this IServiceCollection services)
    {
        // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //     .AddCookie(options =>
        //     {
        //         options.Events.OnRedirectToLogin = (context) =>
        //         {
        //             context.Response.StatusCode = 401;
        //             return Task.CompletedTask;
        //         };
        //     });
        
        
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
}