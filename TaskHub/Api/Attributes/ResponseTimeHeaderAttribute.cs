using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    private const string StopwatchKey = "Debug_Stopwatch";

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        context.HttpContext.Items[StopwatchKey] = stopwatch;
        
        context.HttpContext.Response.OnStarting(() =>
        {
            if (context.HttpContext.Items[StopwatchKey] is Stopwatch sw)
            {
                sw.Stop();
                context.HttpContext.Response.Headers["X-Response-Time-Ms"] = sw.ElapsedMilliseconds.ToString();
            }
            return Task.CompletedTask;
        });
    }
}