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
<<<<<<< HEAD
using Notice.DAL;
using Notice.DAL.Interfaces;
using Notice.DAL.Repositories;
=======
>>>>>>> main

namespace Notice.Web
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
<<<<<<< HEAD
            services.AddMvc();

            services.Configure<DbConnection>(Configuration.GetSection(DbConnection.ConnectionStrings));

            services.AddTransient<IBaseRepository, BaseRepository>();

            services.AddControllersWithViews(options =>
            {
                options.EnableEndpointRouting = false;
            });
=======
            services.AddControllersWithViews();
>>>>>>> main
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

<<<<<<< HEAD
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
=======
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=EditUser}/{id?}");
>>>>>>> main
            });
        }
    }
}
