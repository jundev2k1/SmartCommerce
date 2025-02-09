// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SmartCommerce.Persistence.Common;
using System.IO.Compression;

namespace SmartCommerce.WebAPI
{
	public static class DependencyInjection
	{
		/// <summary>
		/// Add application
		/// </summary>
		public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
		{
			// Connection database
			var connection = configuration.GetConnectionString("ApplicationDb");
			services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(connection, b => b.MigrationsAssembly("SmartCommerce.WebAPI")));

			// Add application service
			services.AddResponseCompressionSetting();

			// Set file size limits
			services.Configure<FormOptions>(option =>
			{
				option.MultipartBoundaryLengthLimit = 10000000;
			});
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.MinimumSameSitePolicy = SameSiteMode.Strict;
			});

			// Dependency injection
			services.AddCommon();

			services.AddControllers();
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder.WithOrigins("*")
						.AllowAnyMethod()
						.AllowAnyHeader());
			});

			// Init handler
			SetConfigurationFileLogger();

			return services;
		}

		/// <summary>
		/// Add common
		/// </summary>
		private static IServiceCollection AddCommon(this IServiceCollection services)
		{
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
			//var config = new LoggerConfiguration()
			//	.MinimumLevel.Verbose()
			//	.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_ERROR,
			//		restrictedToMinimumLevel: LogEventLevel.Error,
			//		rollingInterval: RollingInterval.Day)
			//	.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_WARNING,
			//		restrictedToMinimumLevel: LogEventLevel.Warning,
			//		rollingInterval: RollingInterval.Day)
			//	.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_INFO,
			//		restrictedToMinimumLevel: LogEventLevel.Information,
			//		rollingInterval: RollingInterval.Day)
			//	.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_DEBUG,
			//		restrictedToMinimumLevel: LogEventLevel.Debug,
			//		rollingInterval: RollingInterval.Day)
			//	.WriteTo.File(Constants.CONFIG_APP_LOG_PATH_VERBOSE,
			//		restrictedToMinimumLevel: LogEventLevel.Verbose,
			//		rollingInterval: RollingInterval.Day)
			//	.CreateLogger();
			//Log.Logger = config;
		}

		/// <summary>
		/// Configure application
		/// </summary>
		public static WebApplication Configure(this WebApplication application)
		{
			application
				.ConfigureExtension()
				.ConfigureEnvironment()
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
				.UseHttpsRedirection()
				.UseStaticFiles();

			return application;
		}

		/// <summary>
		/// Configure environment
		/// </summary>
		private static WebApplication ConfigureEnvironment(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			return app;
		}

		/// <summary>
		/// Configure routes
		/// </summary>
		private static WebApplication ConfigureRoutes(this WebApplication app)
		{
			app.MapControllers();
			return app;
		}
	}
}
