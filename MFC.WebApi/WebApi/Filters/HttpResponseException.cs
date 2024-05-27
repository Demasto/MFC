using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public sealed class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        var exceptionMessage = context.Exception.Message;
        
        var response = new Dictionary<string, object?>
        {
            ["succeeded"] = false,
            ["error_message"] = exceptionMessage,
            ["action_name"] = actionName,
            ["StackTrace"] = context.Exception.StackTrace,
        };
        
        context.Result = new ObjectResult(response);
        context.ExceptionHandled = true;
    }
}