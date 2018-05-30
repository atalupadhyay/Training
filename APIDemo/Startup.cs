using System.Text;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using APIDemo.Models;
using APIDemo.Services;
using System.Threading.Tasks;
using System;

namespace APIDemo
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
            // JWT Security
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Issuer"],
                        ValidAudience = Configuration["Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["SigningKey"]))
                    };
                });

            // Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApiDemoContext>()
                .AddDefaultUI();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");

            // SQLServer DB Provider
            services.AddDbContext<ApiDemoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Service Registrierung
            services.AddScoped<ICarsRepository, CarsRepository>(); // Jeder HTTP Request neue Instanz

            // Automapper
            services.AddAutoMapper();

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
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

            // Identity UI
            app.UseAuthentication();

            app.UseHttpsRedirection();

            // Cors Alles Erlauben
            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());
            //app.UseCors("AllowPPEDV");

            app.UseMvc();

            //CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            var roleCheck = await RoleManager.RoleExistsAsync("Teacher");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Teacher"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Student");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Student"));
            }

            var user = await UserManager.FindByEmailAsync("teacher@ppedv.de");
            var User = new IdentityUser();
            await UserManager.AddToRoleAsync(user, "Teacher");

            user = await UserManager.FindByEmailAsync("student@ppedv.de");
            await UserManager.AddToRoleAsync(user, "Student");

        }
    }
}
