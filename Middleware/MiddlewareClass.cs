using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class MiddlewareClass
    {
        private readonly RequestDelegate _next;

        public MiddlewareClass(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("MiddlewareClass Start\r\n");
            await _next(context);
            await context.Response.WriteAsync("MiddlewareClass End\r\n");
        }
    }
}