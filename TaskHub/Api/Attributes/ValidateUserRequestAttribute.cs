using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

public class ValidateUserRequestAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.ActionArguments.Values.FirstOrDefault();

        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }
        
        var nameProperty = request.GetType().GetProperty("Name");
        var nameValue = nameProperty?.GetValue(request) as string;

        if (string.IsNullOrWhiteSpace(nameValue))
        {
            context.Result = new BadRequestObjectResult("Имя пользователя не задано");
        }
    }
}