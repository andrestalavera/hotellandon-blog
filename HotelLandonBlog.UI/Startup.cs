using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotelLandonBlog.Entities;
using HotelLandonBlog.Data;
using HotelLandonBlog.Repository;
using HotelLandonBlog.UI.Controllers;

namespace HotelLandonBlog.UI
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
            var conn = Configuration.GetConnectionString("DefaultConnection");

            // Ajouter le service pour avoir des contr�leurs et des vues associ�es aux contr�leurs
            services.AddControllersWithViews();

            // Ajouter le service pour avoir des pages (sans co
            services.AddRazorPages();

            services.AddDbContext<HotelLandonBlogDbContext>(options => options.UseSqlServer(conn));
            services.AddTransient<IRepository<Category>, RepositoryBase<Category>>();
            services.AddTransient<IRepository<BlogPost>, RepositoryBase<BlogPost>>();
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
                //ajouter des route personnalisé
                endpoints.MapControllerRoute(
                name: "home",
                pattern: "{controller=home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
