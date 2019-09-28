namespace Artity.Web
{
    using System;
    using System.Reflection;

    using Artity.Data;
    using Artity.Data.Common;
    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Data.Repositories;
    using Artity.Data.Seeding;
    using Artity.Services.Data.Artists;
    using Artity.Services.Data.Category;
    using Artity.Services.Data.File;
    using Artity.Services.Data.Offert;
    using Artity.Services.Data.Order;
    using Artity.Services.Data.Performence;
    using Artity.Services.Data.Rating;
    using Artity.Services.Data.Social;
    using Artity.Services.Data.User;
    using Artity.Services.Mapping;
    using Artity.Services.Messaging;
    using Artity.Web.Areas.Administration.ViewModels.Dashboard;
    using Artity.Web.Hubs;
    using Artity.Web.InputModels.Order;
    using Artity.Web.ViewModels;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Framework services
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            Account cloudinaryCredentials = new Account(
              this.configuration["Cloudinary:CloudName"],
              this.configuration["Cloudinary:ApiKey"],
              this.configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);

            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;
                    options.Lockout.AllowedForNewUsers = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserStore<ApplicationUserStore>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = this.configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
            //});

            services.AddSignalR();
            services.AddMvc(options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddRazorPages(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/ArtistRegister");
                });

            services.ConfigureApplicationCookie(options =>
             {
                 options.LoginPath = "/Identity/Account/Login";
                 options.LogoutPath = "/Identity/Account/Logout";
                 options.AccessDeniedPath = "/Identity/Account/AccessDenied";
             });

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.Lax;
                    options.ConsentCookie.Name = ".AspNetCore.ConsentCookie";
                });

            services.AddSingleton(this.configuration);

            // Identity stores
            services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
            services.AddIdentityCore<ApplicationUser>();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<ISeeder, RolesSeeder>();
            services.AddTransient<ISendGrid, SendGridEmailSender>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IPerformenceService, PerformenceService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOffertService, OffertService>();
            services.AddTransient<IOffertService, OffertService>();
            services.AddTransient<ISocialService, SocialService>();
            services.AddTransient<IPicureService, PictureService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, ISeeder seeder, ApplicationDbContext context)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(ArtistOrderCreateInputModel).GetTypeInfo().Assembly, typeof(ApprovedArtistViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment() || env.IsProduction())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

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

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHub<NotifyHub>("/notify");
                });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            seeder.SeedAsync(context, serviceProvider);
        }
    }
}
