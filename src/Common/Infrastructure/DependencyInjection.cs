// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.BackgroundServices;
using ErpManager.Infrastructure.Logging;
using ErpManager.Infrastructure.Mail;
using Microsoft.AspNetCore.Builder;

namespace ErpManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddDependencyInjection();
            services.AddBackgroundService();
            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
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

        public static IApplicationBuilder UseInfrastructureMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SessionCheckMiddleware>();
            return app;
        }
    }
}