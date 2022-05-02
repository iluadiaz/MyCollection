using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using TFA.Models;
using TFA.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace TFA
{
    public class Startup
    {
        private string connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("TFAConnectionAzure"));
            //builder.Password = Configuration["TFA:DBPassword"];

            services.AddControllersWithViews();
            services.AddRazorPages();
           // services.AddDbContext<__TFADbContext>(options =>
           //   options.UseSqlServer(Configuration.GetConnectionString("__TFAConnection"))
           //);
            services.AddDbContext<__TFADbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("TFAConnectionAzure"))
           );
                        services.AddDbContext<TFAIdentityDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("TFAConnectionAzureIdentity"))
           );
         //   services.AddDbContext<TFAIdentityDbContext>(options =>
         //   options.UseSqlServer(Configuration.GetConnectionString("TFAIdentityDbContextConnection"))
         //);
            services.AddControllersWithViews();
            // Added to enable runtime compilation
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                            .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TFAIdentityDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<DbContext, __TFADbContext>();
            services.AddScoped<IAthleteRepository, AthleteRepository>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<ITrackEventRepository, TrackEventRepository>();
            services.AddScoped<IRaceResultRepository, RaceResultRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

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

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
            });
        }
    }
}
