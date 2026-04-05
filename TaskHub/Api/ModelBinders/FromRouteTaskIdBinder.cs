using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.ModelBinders;

public class FromRouteTaskIdBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null) 
            throw new ArgumentNullException(nameof(bindingContext));

        var valueProviderResult = bindingContext.ValueProvider.GetValue("id");

        if (valueProviderResult == ValueProviderResult.None)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        if (!Guid.TryParse(value, out var guidResult))
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Идентификатор задачи имеет некорректный формат");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        bindingContext.Result = ModelBindingResult.Success(guidResult);
        return Task.CompletedTask;
    }
}