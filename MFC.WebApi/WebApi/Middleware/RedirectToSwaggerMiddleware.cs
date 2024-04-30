namespace WebApi.Middleware;

public class RedirectToSwaggerMiddleware(RequestDelegate next)
{
    
    public async Task Invoke(HttpContext context)
    {
        if(context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
        }
        else
        {
            await next(context);
        }
    }
}