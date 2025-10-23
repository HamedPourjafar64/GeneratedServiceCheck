using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthService.Api.Filters;

/// <summary>
/// Filter for validating model state
/// </summary>
public class ValidationFilter : IActionFilter
{
    /// <summary>
    /// Executes before the action method
    /// </summary>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? Array.Empty<string>()
                );

            var result = new
            {
                status = 400,
                message = "Validation failed",
                errors
            };

            context.Result = new BadRequestObjectResult(result);
        }
    }

    /// <summary>
    /// Executes after the action method
    /// </summary>
    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Not needed
    }
}
