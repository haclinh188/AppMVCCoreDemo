using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.AspNetCore.MVC.RazorPage
{
    public class Startup
    {
        public static string ContentPath { get; set; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            ContentPath = env.ContentRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // Them cau hinh razorpage  (demo them)
            services.AddRazorPages();

            //Add config RazorViewEngine
            services.Configure<RazorViewEngineOptions>(option =>
            {

                //MyViews/Controller/ActionView (cshtml)
                //{0} Action
                //{1} Tên controller
                //{2} Ten Area

                // Ví dụ muốn dùng cho Views  thì viết như sau 
                // option.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml"); hoặc cach viet phia duoi theo phần mở rộng view   ( Tìm tất cả trong Views)
                option.ViewLocationFormats.Add("/Views/{1}/{0}" + RazorViewEngine.ViewExtension);

            });

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

            app.UseAuthentication(); // Xác thực danh tính người dùng
            app.UseAuthorization(); // Xác thực quyền truy cập của người dùng

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
