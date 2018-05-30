using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcDemo.Helpers;
using MvcDemo.Models;

namespace MvcDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // In Memory DB
            #region InMemoryDB
            services.AddDbContext<MvcDemoContext>(options =>
            {
                options.UseInMemoryDatabase("CarRental");
            });
            #endregion

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();

            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                #region GeneralExceptions
                //app.UseExceptionHandler("/Helper/Error");
                #endregion

                #region StatusCodePages
                //app.UseStatusCodePages();                
                #endregion

                #region CustomErrorPageFürStatuscode
                app.UseStatusCodePagesWithReExecute("/Helper/ErrorCustom", "?statusCode={0}");
                #endregion

                // app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();

            // 1. Default Routing
            // app.UseMvcWithDefaultRoute();

            // 2. Conventional Routing
            //app.UseMvc(routes => 
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}",
            //        defaults: new { controller="Cars", action="Index" });

            //    // Params
            //    routes.MapRoute(
            //        name: "carRoute",
            //        template: "{controller}/{id?}/{action}",
            //        defaults: new { controller="Cars", action = "Details" });

            //    // Constraints
            //    routes.MapRoute(
            //        name: "carRoute1",
            //        template: "{controller}/{id:alpha}/{action}",
            //        defaults: new { controller = "Cars", action = "Test" });
            //});

            // 3. Route in Klasse
            app.UseCarRentalRouter();
        }
    }
}
