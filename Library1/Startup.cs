using Library.Data.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library1.Interface;
using Library1.Service;

namespace Library1
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
            
            // services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["MySQLConnectionStrings:Default1"]));
            // services.Configure<MySqlConfiguration>(Configuration.GetSection("MySQLConnectionStrings"));
            //services.AddDbContext<LibraryDbContext>();

            services.Configure<MySqlConfiguration>(Configuration.GetSection("MySQLConnectionStrings"));
            services.AddDbContext<LibraryDbContext>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IReadersService, ReadersService>();

            services.AddAutoMapper(typeof(MappingProfiles));



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
