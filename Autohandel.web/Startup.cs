using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autohandel.web.Services;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Autohandel.web.Interfaces;
using Autohandel.web.Repositories;



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
            services.AddTransient<IOnderdelenProductenRepository, OnderdelenProductenRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
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
               

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("administrator"));
            });
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddAutoMapper();
            services.AddMvc()
                .AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Winkelkar.GetWinkelkar(sp));

            //services.AddMvc()
            //    .AddSessionStateTempDataProvider();

            // Adds a default in-memory implementation of IDistributedCache.
            //services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession();

            //services.AddSession(options =>
            //{
            //    // Set a short timeout for easy testing.
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //});

          

            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSession();
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

                    //DataSeeder.Seed(context);
                }
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSignalR(routes =>
            {
                routes.MapHub<Chat>("/chat");
            });

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
