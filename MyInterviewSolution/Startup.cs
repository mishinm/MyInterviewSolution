using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using WebApplication1.Models;
using WebApplication1.Services;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            CultureInfo.CurrentCulture=new CultureInfo("ru-RU");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var SERVER = Configuration["SERVER"];
            var USER = Configuration["USER"];
            var PSW = Configuration["PASSWORD"];
            var DB_CATALOG = Configuration["CATALOG"];
            var minor = Configuration["MINOR"];
            var major = Configuration["MAJOR"];
            var build = Configuration["BUILD"];

            int _minor = Convert.ToInt32(minor);
            int _major = Convert.ToInt32(major);
            int _build = Convert.ToInt32(build);

           services.AddDbContext<ApplicationContext>(options => {
                options.UseMySql($"server={SERVER};user={USER};password={PSW};database={DB_CATALOG}",new MySqlServerVersion(new Version(_major, _minor, _build)));
            });

            services.AddControllersWithViews(); 
            services.AddScoped<HomeServices>();
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
            }
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
