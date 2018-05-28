using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDemo.Helpers
{
    public static class MiddlewareExtensions
    {
        // 1. Run Middleware
        public static void RunHelloPpedv(this IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello PPEDV 1!");
            });
        }

        // 2. Use Middleware in class
        public static IApplicationBuilder UseHelloPpedvClass(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloPpedvMiddleware>();
        }

        // 3. From Method
        public static IApplicationBuilder UseHelloPpedv(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello PPEDV 2!");
                await next();
            });
        }
    }
}
