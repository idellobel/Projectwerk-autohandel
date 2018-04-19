using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autohandel.web.ViewModels;
using Autohandel.web.Services;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;

namespace Autohandel.web
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
            //services.AddDbContext<ApplicationDbContext>(options =>
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AutohandelContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AutohandelDb")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddIdentity<ApplicationUser, IdentityRole>(
                config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                }
                )
                .AddEntityFrameworkStores<AutohandelContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "";
                googleOptions.ClientSecret = "";
            });  
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();

                //create a scope with which to get the DbContext service (yuck!) 
                using (var serviceScope = app.ApplicationServices
                                             .GetRequiredService<IServiceScopeFactory>()
                                             .CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<AutohandelContext>(); //get DbContext 

                    /*De seedMethode dient uitgecommentariëerd te worden bij uitvoeren migratie/update database!!!!*/

                    DataSeeder.Seed(context);
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=index}/{id?}"
                    );
                //other routes...
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
