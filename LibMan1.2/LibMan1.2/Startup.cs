using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LibMan1._2.Models;
using LibMan1._2.Models.DB;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LibMan1._2
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
            services.AddRazorPages();

            services.AddDbContext<LibManContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EFCoreDBFirstDemoDatabase")));

            services.AddSession();
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme =
               CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme =
               CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
               CookieAuthenticationDefaults.AuthenticationScheme;
            })
             .AddCookie();
            services.AddMvc();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
