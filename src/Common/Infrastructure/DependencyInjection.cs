// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Builder;
using SmartCommerce.Infrastructure.BackgroundServices;
using SmartCommerce.Infrastructure.Logging;
using SmartCommerce.Infrastructure.Mail;
using SmartCommerce.Resource.Localizers.Fields;
using SmartCommerce.Resource.Localizers.Globals;
using SmartCommerce.Resource.Localizers.Messages;
using SmartCommerce.Resource.Localizers.StringFormats;
using SmartCommerce.Resource.Localizers.Validators;
using SmartCommerce.Resource.Localizers.ValueTexts;
using System.Globalization;

namespace SmartCommerce.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services
				.AddLocalizationSetting()
				.AddUtility()
				.AddBackgroundService()
				.AddSignalR();
			return services;
		}

		private static IServiceCollection AddUtility(this IServiceCollection services)
		{
			services.AddSingleton<IFileLogger, FileLogger>();
			services.AddSingleton<IMailSender, MailSender>();
			return services;
		}

		private static IServiceCollection AddBackgroundService(this IServiceCollection services)
		{
			services.AddHostedService<NotificationBackgroundService>();
			services.AddHostedService<DeleteTempUploadDirBackgroundService>();
			return services;
		}

		/// <summary>
		/// Add localization setting
		/// </summary>
		private static IServiceCollection AddLocalizationSetting(this IServiceCollection services)
		{
			services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
			services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

			// Add localizations
			var localizerlist = new List<Type>
			{
				typeof(GlobalsLocalizer),
				typeof(FieldsLocalizer),
				typeof(MessagesLocalizer),
				typeof(StringFormatsLocalizer),
				typeof(ValidatorsLocalizer),
				typeof(ValueTextsLocalizer),
			};
			localizerlist.ForEach(type =>
			{
				services.AddSingleton(typeof(IStringLocalizer<>).MakeGenericType(type), provider =>
				{
					var factory = provider.GetRequiredService<IStringLocalizerFactory>();
					return ActivatorUtilities.CreateInstance(provider, typeof(StringLocalizer<>).MakeGenericType(type), factory);
				});
			});

			// Set configure option
			services.Configure<RequestLocalizationOptions>(option =>
			{
				var supportedLanguage = new[]
				{
					new CultureInfo(Constants.FLG_GLOBAL_CULTURE_VN),
					new CultureInfo(Constants.FLG_GLOBAL_CULTURE_ENG),
				};
				option.DefaultRequestCulture = new RequestCulture(Constants.FLG_GLOBAL_CULTURE_VN);
				option.SupportedCultures = supportedLanguage;
				option.SupportedUICultures = supportedLanguage;
			});

			return services;
		}

		public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
		{
			app.UseMiddleWare();
			return app;
		}

		private static IApplicationBuilder UseMiddleWare(this IApplicationBuilder app)
		{
			app.UseMiddleware<RateLimitingMiddleware>();
			app.UseMiddleware<CompressionMiddleware>();
			app.UseMiddleware<ResetConstantHandlerMiddleware>();
			return app;
		}
	}
}