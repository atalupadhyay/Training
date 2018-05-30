using Microsoft.AspNetCore.Builder;

namespace MvcDemo.Helpers
{
    public static class ApplicationExtensions
    {
        #region RouteMiddleware
        public static IApplicationBuilder UseCarRentalRouter
            (this IApplicationBuilder app)
        {
            app.UseMvc(routes => new MvcDemoRouter(routes));
            return app;
        }
        #endregion
    }
}
