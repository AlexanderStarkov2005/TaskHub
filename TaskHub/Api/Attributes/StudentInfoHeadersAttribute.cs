using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class StudentInfoHeadersAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Response.Headers["X-Student-Name"] = "Mironov Egor Pavlovich";
        context.HttpContext.Response.Headers["X-Student-Group"] = "RI-240948";
    }
}