using GhostProject.App.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace GhostProject.App.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseBusinessExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
