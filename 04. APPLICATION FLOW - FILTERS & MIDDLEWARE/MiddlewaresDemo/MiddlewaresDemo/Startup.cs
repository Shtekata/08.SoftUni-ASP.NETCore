using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddlewaresDemo.Middlewares;

namespace MiddlewaresDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            //app.UseWelcomePage();
            app.Map("/healthcheck", x =>
            {
                x.Run(async (context) =>
                {
                    await context.Response.WriteAsync("I am alive!");
                });
            });
            app.UseMiddleware<RedirectToGoogleIfNotHttpsMiddleware>();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("BEFORE...");
                if (DateTime.UtcNow.Second % 2 == 0)
                {
                    await next();
                }
                await context.Response.WriteAsync("...AFTER");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from middleware!");
                await next();
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("I am last!");
            });
        }
    }
}
