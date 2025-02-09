// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Builder;
using SmartCommerce.Infrastructure.BackgroundServices;
using SmartCommerce.Infrastructure.Logging;
using SmartCommerce.Infrastructure.Mail;

namespace SmartCommerce.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddSignalR();
			services.AddUtility();
			services.AddBackgroundService();
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