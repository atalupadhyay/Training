using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MvcDemo.Helpers
{
    public class MvcDemoRouter
    {
        #region DemoRouter
        private IRouteBuilder _routes;

        public MvcDemoRouter(IRouteBuilder routes)
        {
            _routes = routes;
            ConfigureCarRoutes();
        }

        private void ConfigureCarRoutes()
        {
            _routes.MapRoute(
                name: "default",
                template: "{controller}/{action}",
                defaults: new { controller = "Cars", action = "Index" });

            // Params
            _routes.MapRoute(
                name: "carRoute",
                template: "{controller}/{id?}/{action}",
                defaults: new { controller = "Cars", action = "Details" });

            // Constraints
            _routes.MapRoute(
                name: "carRoute1",
                template: "{controller}/{id:alpha}/{action}",
                defaults: new { controller = "Cars", action = "Test" });
        }
        #endregion
    }
}
