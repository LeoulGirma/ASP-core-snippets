using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Image_upload.Data;
using Image_upload.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Image_upload
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration   Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //only one instance is used through out the application
            //transient = each time it is requested
            //scopedone = instance per request is created 

            //services.AddSingleton<IMovieRepository, MockMovieRepository>();

            /*
             * Now all we need to do is replace the implmenting class to the one that uses the db context
             * its because both this methods implment the same thing but in a differnet way
             * and also we dont have special methods on each class both have the exact same method that are only specified in the interface
             * that is why its working with only one line
             */
             /*
              * we use scoped bc we want the sqlmovierepository instance to be alive and avilable through an entire scope
              * of a given http request
              * when new http req comes we want another new instance of this class whyy tho??
              */
            services.AddScoped<IMovieRepository, SQLMovieRepository>();
            /*
             *first Registering our dbcontext class 
             *options parametter to choose db provider extention method
             * and get connection string from app seeting.json using the i configration service
             */
            services.AddDbContextPool<MovieContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("Cinema")));
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
