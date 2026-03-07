namespace Api.Middlewares;

public class StudentInfoMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public StudentInfoMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers.Add("X-Student-Name", "Mironov Egor Pavlovich");
        context.Response.Headers.Add("X-Student-Group", "RI-240948");
        
        await _next(context);
    }
}