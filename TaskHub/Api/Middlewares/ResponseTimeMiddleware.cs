using System.Diagnostics;

namespace Api.Middlewares;

public class ResponseTimeMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;
        
        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;
            
            var stopwatch = Stopwatch.StartNew();
            
            try
            {
                await next(context);
                
                stopwatch.Stop();
                
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                context.Response.Headers.Add("X-Response-Time-Ms", elapsedMilliseconds.ToString());
                
                responseBody.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }
        }
    }
}