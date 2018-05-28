using APIDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // SQLServer DB
            services.AddDbContext<ApiDemoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Cors
            services.AddCors();
            //services.AddCors(options => 
            //{
            //    options.AddPolicy("AllowPPEDV",
            //        builder => 
            //        {
            //            //builder.WithOrigins("http://ppedv.de");
            //            builder.WithMethods("GET");
            //        });
            //});

            services
                .AddMvc(config =>
                {
                    // XML
                    config.RespectBrowserAcceptHeader = true;
                    config.InputFormatters.Add(new XmlSerializerInputFormatter());
                    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                })
                // Capital Letters First
                //.AddJsonOptions(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver())

                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Security Headers
                // Weitere Security Header
                // https://securityheaders.io/
                app.UseHsts();
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
            }

            app.UseHttpsRedirection();

            // Cors Alles Erlauben
            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            //app.UseCors("AllowPPEDV");

            app.UseMvc();
        }
    }
}
