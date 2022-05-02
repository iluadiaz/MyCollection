using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HW3.DAL.Abstract;
using HW3.DAL.Concrete;

namespace HW3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string key = null;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IGitHubService, GitHub>();
            key = Configuration["Token:ServiceApiKey"];

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "API GitHub",
                    pattern: "GetUser",
                    defaults: new { controller = "Home", action = "GetAUser" });

                endpoints.MapControllerRoute(
                    name: "API GitHub",
                    pattern: "repositories",
                    defaults: new { controller = "Home", action = "GetRepositoriesList" });

                endpoints.MapControllerRoute(
                    name: "API GitHub",
                    pattern: "repository",
                    defaults: new { controller = "Home", action = "GetARepository" });

                endpoints.MapControllerRoute(
                    name: "API GitHub",
                    pattern: "branch",
                    defaults: new { controller = "Home", action = "GetBranchList" });

                endpoints.MapControllerRoute(
                    name: "API GitHub",
                    pattern: "commit",
                    defaults: new { controller = "Home", action = "GetCommitList" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
