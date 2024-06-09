// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Infrastructure.Common.Middleware;
using ErpManager.Infrastructure.Interface;
using ErpManager.Infrastructure.Logging;
using ErpManager.Infrastructure.Mail;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace ErpManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDependencyInjection();
            UseFileLogger();
            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IFileLogger, FileLogger>();
            services.AddSingleton<IMailSender, MailSender>();
            return services;
        }

        private static void UseFileLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(Constants.CONFIG_APP_LOG_PATH_INFO, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(Constants.CONFIG_APP_LOG_PATH_WARNING, restrictedToMinimumLevel: LogEventLevel.Warning, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(Constants.CONFIG_APP_LOG_PATH_ERROR, restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(Constants.CONFIG_APP_LOG_PATH_VERBOSE, restrictedToMinimumLevel: LogEventLevel.Verbose, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(Constants.CONFIG_APP_LOG_PATH_DEBUG, restrictedToMinimumLevel: LogEventLevel.Debug, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public static IApplicationBuilder UseInfrastructureMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SessionCheckMiddleware>();
            return app;
        }
    }
}