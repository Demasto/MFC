namespace WebApi.Middleware;

public class RedirectToSwaggerMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectToSwaggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
        }
        else
        {
            await _next(context);
        }
    }
}