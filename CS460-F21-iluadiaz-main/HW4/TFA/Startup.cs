using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TFA.DAL.Abstract;
using TFA.DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using TFA.Models;


namespace TFA
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
            services.AddControllersWithViews();
            services.AddDbContext<__TFADbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("__TFAConnection"))
           );
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
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    
            });
        }
    }
}
