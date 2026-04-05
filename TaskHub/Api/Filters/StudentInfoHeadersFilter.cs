using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class StudentInfoHeadersFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var executedContext = await next();
        executedContext.HttpContext.Response.Headers.Append("X-Student-Name", "Mironov Egor Pavlovich");
        executedContext.HttpContext.Response.Headers.Append("X-Student-Group", "RI-240948");
    }
}