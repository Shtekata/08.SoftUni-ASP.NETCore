using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFirstAspNetCoreApp.Filters;
using MyFirstAspNetCoreApp.ModelBinders;
using MyFirstAspNetCoreApp.RouteConstraints;
using MyFirstAspNetCoreApp.Services;

namespace MyFirstAspNetCoreApp
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
            //scoped application db context & repositories
            services.AddControllersWithViews(x=> 
            {
                x.ModelBinderProviders.Insert(0, new YearModelBinderProvider());
                //x.Filters.Add<AddHeaderActionFilterAttribute>();
                //x.Filters.Add(new AddHeaderActionFilterAttribute());
                x.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddRouting(x => x.ConstraintMap.Add("cyrillic", typeof(CyrillicRouteConstraint)));
            services.AddRazorPages();
            services.AddMvc(x => x.Filters.Add<AddHeaderActionFilterAttribute>());
            //services.AddMvc(x => x.Filters.Add(new AddHeaderAsyncActionFilterAttribute("X-Debug","Global!!!")));
            services.AddMvc(x => x.Filters.Add(new CustomPageFilter()));
            services.AddTransient<IStringManipulation, StringManipulation>();
            services.AddTransient<IYearsService, YearsService>();
            //services.AddTransient<IYearsService>((sp) => new YearsService(Configuration["YouTube:ApiKey"]));
            //services.AddTransient<YearsService>();
            services.AddTransient<ICountInstancesService, CountInstancesService>();
            services.AddTransient<IPositionsService, PositionsService>();
            services.AddTransient<AddHeaderActionFilterAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseExceptionHandler("/Home/Error");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseStatusCodePagesWithReExecute("/Home/MyNotFound");
            app.UseStatusCodePagesWithRedirects("/Home/HttpError?ErrorIs={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "blogUrl",
                   pattern: "Blog/{slug}/{id:int}",
                   defaults: new { controller = "Home", action = "Blog" });
                endpoints.MapRazorPages();
            });
        }
    }
}
