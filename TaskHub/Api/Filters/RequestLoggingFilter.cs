using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class RequestLoggingFilter(ILogger<RequestLoggingFilter> logger) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var httpContext = context.HttpContext;
        logger.LogInformation("Начало: {Method} {Path}", httpContext.Request.Method, httpContext.Request.Path);

        var sw = Stopwatch.StartNew();
        var executedContext = await next();
        sw.Stop();

        logger.LogInformation("Завершено: {StatusCode}, время: {Elapsed} мс", 
            httpContext.Response.StatusCode, sw.ElapsedMilliseconds);
    }
}