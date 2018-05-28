using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareDemo.Helpers
{
    public class HelloPpedvMiddleware
    {
        private readonly RequestDelegate _next;
        public HelloPpedvMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Hello PPEDV 3!");
        }
    }
}
