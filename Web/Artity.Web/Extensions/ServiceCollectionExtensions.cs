namespace Artity.Web.Extensions
{
    using System;

    using Artity.Data;
    using Artity.Data.Common;
    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Data.Repositories;
    using Artity.Data.Seeding;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ISeeder, RolesSeeder>();
            //services.AddTransient<ISendGrid, SendGridEmailSender>();
            //services.AddTransient<ICategoryService, CategoryService>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IArtistService, ArtistService>();
            //services.AddTransient<ICloudinaryService, CloudinaryService>();
            //services.AddTransient<IPerformenceService, PerformenceService>();
            //services.AddTransient<IRatingService, RatingService>();
            //services.AddTransient<IOrderService, OrderService>();
            //services.AddTransient<IOffertService, OffertService>();
            //services.AddTransient<IOffertService, OffertService>();
            //services.AddTransient<ISocialService, SocialService>();
            //services.AddTransient<IPicureService, PictureService>();

            return services;
        }

        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            return services;
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
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

            return services;
        }

        public static IServiceCollection RegisterCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            //Account cloudinaryCredentials = new Account(
            //    configuration["Cloudinary:CloudName"],
            //    configuration["Cloudinary:ApiKey"],
            //    configuration["Cloudinary:ApiSecret"]);

            //Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            //services.AddSingleton(cloudinaryUtility);

            return services;
        }

        public static IServiceCollection RegisterCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/Identity/Account/Logout";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.Lax;
                    options.ConsentCookie.Name = ".AspNetCore.ConsentCookie";
                });

            return services;
        }
    }
}