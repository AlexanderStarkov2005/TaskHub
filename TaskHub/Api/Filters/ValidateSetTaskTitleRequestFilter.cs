using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ValidateSetTaskTitleRequestFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var title = context.ActionArguments.Values.FirstOrDefault(v => v is string) as string;

        if (string.IsNullOrWhiteSpace(title))
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        await next();
    }
}