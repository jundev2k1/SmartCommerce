using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ErpManager.Web
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application
        /// </summary>
        /// <param name="services">Services</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Connection database
            var connection = configuration.GetConnectionString("ErpManager");
            services.AddDbContext<DBContext>(x => x.UseSqlServer(connection, b => b.MigrationsAssembly("ErpManager.Web")));

            // Add session
            services.AddSessionSetting();

            // Add multiple language
            services.AddLocalizationSetting();

            // Add services to the container.
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            return services;
        }

        /// <summary>
        /// Add persistence
        /// </summary>
        /// <param name="services">Service</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<AppConfiguration>();
            
            // Dependency injection
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        /// <summary>
        /// Add session setting
        /// </summary>
        /// <param name="services">Service</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection AddSessionSetting(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            return services;
        }

        /// <summary>
        /// Add localization setting
        /// </summary>
        /// <param name="services">Service</param>
        /// <returns>Service collection</returns>
        private static IServiceCollection AddLocalizationSetting(this IServiceCollection services)
        {
            services.AddLocalization(option => option.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedLanguage = new[]
                {
                    new CultureInfo("vi-VN"),
                    new CultureInfo("en-US"),
                };
                options.DefaultRequestCulture = new RequestCulture("vi-VN");
                options.SupportedCultures = supportedLanguage;
                options.SupportedUICultures = supportedLanguage;
            });

            return services;
        }
    }
}
