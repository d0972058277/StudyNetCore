using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareExtensionClass(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareExtensionClass>();
        }
    }

    public class MiddlewareExtensionClass
    {
        private readonly RequestDelegate _next;

        public MiddlewareExtensionClass(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("MiddlewareExtensionClass Start\r\n");
            await _next(context);
            await context.Response.WriteAsync("MiddlewareExtensionClass End\r\n");
        }
    }
}