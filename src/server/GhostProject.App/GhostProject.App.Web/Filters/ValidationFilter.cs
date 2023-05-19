using GhostProject.App.Web.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GhostProject.App.Web.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new ModelValidationFailedException("Bad request", context.ModelState);
            }
        }
    }
}
