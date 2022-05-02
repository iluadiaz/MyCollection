using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TFA.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TFA.Areas.Identity.IdentityHostingStartup))]
namespace TFA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<TFAIdentityDbContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("TFAConnectionAzureIdentity"))
                //    );
                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //                .AddRoles<IdentityRole>()
                //    .AddEntityFrameworkStores<TFAIdentityDbContext>();
            });

        }
    }
}
