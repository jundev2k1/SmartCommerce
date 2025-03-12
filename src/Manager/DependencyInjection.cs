// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Common.Localizer;
using SmartCommerce.Manager.Common.Validators;
using SmartCommerce.Infrastructure.Hubs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;
using System.Globalization;
using System.IO.Compression;

namespace SmartCommerce.Manager
{
	public static class DependencyInjection
	{
		/// <summary>
		/// Add application
		/// </summary>
		public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
		{
			// Connection database
			var connection = configuration.GetConnectionString("SmartCommerceDB");
			services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(connection, b => b.MigrationsAssembly("SmartCommerce.Manager")));

			// Add application service
			services
				.AddSessionSetting()
				.AddLocalizationSetting()
				.AddResponseCompressionSetting();

			// Set file size limits
			services.Configure<FormOptions>(option =>
			{
				option.MultipartBoundaryLengthLimit = 10000000; // 10MB
			});
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.MinimumSameSitePolicy = SameSiteMode.Strict;
			});

			// Init configuration
			new AppConfiguration(configuration).Initialize();

			// Dependency injection
			services.AddCommon();
			services.RegisterValidations();

#pragma warning disable CS0618

			// Add services to the container.
			services
				.AddControllersWithViews(option => option.Filters.AddApplicationFilters())
				.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
				.AddDataAnnotationsLocalization()
				.AddFluentValidation();

#pragma warning restore CS0618

			// Init handler
			ConstantHandler.Initialize(configuration);
			SetConfigurationFileLogger();

			return services;
		}

		/// <summary>
		/// Add application filter
		/// </summary>
		/// <param name="filters">Filter collection</param>
		/// <returns>Filter collection</returns>
		private static FilterCollection AddApplicationFilters(this FilterCollection filters)
		{
			filters.AddService<AuthorizationFilter>();
			return filters;
		}

		/// <summary>
		/// Add common
		/// </summary>
		private static IServiceCollection AddCommon(this IServiceCollection services)
		{
			services.AddSingleton<ILocalizer, Localizer>();
			services.AddTransient<IValidatorFacade, ValidatorFacade>();
			services.AddScoped<SessionManager>();
			services.AddSingleton<ValueTextManager>();

			// Add filter
			services.AddScoped<AuthorizationFilter>();
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
			services.AddHttpContextAccessor();

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
					new CultureInfo(Constants.FLG_GLOBAL_CULTURE_VN),
					new CultureInfo(Constants.FLG_GLOBAL_CULTURE_ENG),
				};
				options.DefaultRequestCulture = new RequestCulture(Constants.FLG_GLOBAL_CULTURE_VN);
				options.SupportedCultures = supportedLanguage;
				options.SupportedUICultures = supportedLanguage;
			});

			return services;
		}

		/// <summary>
		/// Add response compression setting
		/// </summary>
		private static IServiceCollection AddResponseCompressionSetting(this IServiceCollection services)
		{
			services.AddResponseCompression(options =>
			{
				options.EnableForHttps = true;
				options.Providers.Add<BrotliCompressionProvider>();
				options.Providers.Add<GzipCompressionProvider>();
				options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
					new[] { "image/svg+xml" });
			});
			services.Configure<BrotliCompressionProviderOptions>(options =>
			{
				options.Level = CompressionLevel.Fastest;
			});
			services.Configure<GzipCompressionProviderOptions>(options =>
			{
				options.Level = CompressionLevel.Optimal;
			});

			return services;
		}

		/// <summary>
		/// Set configuration file logger
		/// </summary>
		private static void SetConfigurationFileLogger()
		{
			var config = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_ERROR,
					restrictedToMinimumLevel: LogEventLevel.Error,
					rollingInterval: RollingInterval.Day)
				.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_WARNING,
					restrictedToMinimumLevel: LogEventLevel.Warning,
					rollingInterval: RollingInterval.Day)
				.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_INFO,
					restrictedToMinimumLevel: LogEventLevel.Information,
					rollingInterval: RollingInterval.Day)
				.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_DEBUG,
					restrictedToMinimumLevel: LogEventLevel.Debug,
					rollingInterval: RollingInterval.Day)
				.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_VERBOSE,
					restrictedToMinimumLevel: LogEventLevel.Verbose,
					rollingInterval: RollingInterval.Day)
				.CreateLogger();
			Log.Logger = config;
		}

		/// <summary>
		/// Register validations (dependency injection)
		/// </summary>
		private static IServiceCollection RegisterValidations(this IServiceCollection services)
		{
			services.AddTransient<IValidator<UserModel>, UserValidator>();
			services.AddTransient<IValidator<RoleModel>, RoleValidator>();
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
				.UseResponseCompression()
				.UseSession()
				.UseHttpsRedirection()
				.UseStaticFiles()
				.UseSerilogRequestLogging();

			return application;
		}

		/// <summary>
		/// Configure environment
		/// </summary>
		private static WebApplication ConfigureEnvironment(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UsePathBase(Constants.CONFIG_APP_BASE_PATH);
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
				pattern: "{area:exists}/{controller=Authentication}/{action=Index}/{id?}");
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Authentication}/{action=Index}/{id?}");
			app.UseInfrastructureMapHub();

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

		public static WebApplication UseInfrastructureMapHub(this WebApplication app)
		{
			app.MapHub<NotificationHub>(Constants.HUB_PATH_NOTIFICATION);

			return app;
		}
	}
}
