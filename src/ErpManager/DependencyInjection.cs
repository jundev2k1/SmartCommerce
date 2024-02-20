using ErpManager.ERP.Common;
using ErpManager.ERP.Common.Extensions;
using ErpManager.ERP.Common.Localizer;
using ErpManager.ERP.Common.Middleware;
using ErpManager.ERP.Common.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ErpManager.ERP
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
        {
            // Connection database
            var connection = configuration.GetConnectionString("ErpManager");
            services.AddDbContext<DBContext>(x => x.UseSqlServer(connection, b => b.MigrationsAssembly("ErpManager.ERP")));

            // Add application service
            services
                .AddSessionSetting()
                .AddLocalizationSetting()
                .AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            // Dependency injection
            services.AddCommon();
            services.RegisterValidations();

#pragma warning disable CS0618

            // Add services to the container.
            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddFluentValidation();

#pragma warning restore CS0618

            return services;
        }

        /// <summary>
        /// Add common
        /// </summary>
        private static IServiceCollection AddCommon(this IServiceCollection services)
        {
            services.AddSingleton<AppConfiguration>();
            services.AddScoped<ILocalizer, Localizer>();
            services.AddTransient<IValidatorFacade, ValidatorFacade>();
            return services;
        }

        /// <summary>
        /// Add session setting
        /// </summary>
        private static IServiceCollection AddSessionSetting(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(Constants.AUTH_EXPIRES_SESSION);
            });

            return services;
        }

        /// <summary>
        /// Add localization setting
        /// </summary>
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
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedLanguage;
                options.SupportedUICultures = supportedLanguage;
            });

            return services;
        }

        /// <summary>
        /// Register validations (dependency injection)
        /// </summary>
        private static IServiceCollection RegisterValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserModel>, UserValidator>();
            services.AddTransient<IValidator<ProductModel>, ProductValidator>();

            return services;
        }

        /// <summary>
        /// Configure application
        /// </summary>
        public static WebApplication Configure(this WebApplication application)
        {
            application
                .ConfigureExtension()
                .ConfigureEnvironment()
                .ConfigureLocalization()
                .ConfigureRoutes();

            return application;
        }

        /// <summary>
        /// Configure extension
        /// </summary>
        private static WebApplication ConfigureExtension(this WebApplication application)
        {
            application
                .ConfigureLocalization()
                .UseSession()
                .UseHttpsRedirection()
                .UseStaticFiles();

            return application;
        }

        /// <summary>
        /// Configure environment
        /// </summary>
        private static WebApplication ConfigureEnvironment(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(Constants.MODULE_ERROR_ERROR_PATH);
                app.UseHsts();
            }
            return app;
        }

        /// <summary>
        /// Configure routes
        /// </summary>
        private static WebApplication ConfigureRoutes(this WebApplication app)
        {
            app.UseRouting();
            app.MapControllerRoute(
                name: "Features",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

        /// <summary>
        /// Configure localization
        /// </summary>
        private static WebApplication ConfigureLocalization(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var localizationOptions = scope.ServiceProvider
                    .GetRequiredService<IOptions<RequestLocalizationOptions>>()
                    .Value;
                app.UseRequestLocalization(localizationOptions);
            }

            return app;
        }

        /// <summary>
        /// Configure middleware
        /// </summary>
        public static IApplicationBuilder UserApplicationMiddleware(this IApplicationBuilder app)
        {
            // Middleware
            app.UseMiddleware<PermissionHandlerMiddleware>();

            return app;
        }
    }
}
