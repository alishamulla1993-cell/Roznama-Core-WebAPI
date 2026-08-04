using Microsoft.AspNetCore.Builder;

namespace Roznama.Common.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalException(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandler>();
        }
    }
}