// Copyright (c) 2024 - Jun Dev. All rights reserved

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
                .WriteTo.File("logs/information.log", rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/warning.log", restrictedToMinimumLevel: LogEventLevel.Warning, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/error.log", restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/verbose.log", restrictedToMinimumLevel: LogEventLevel.Verbose, rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/debug.log", restrictedToMinimumLevel: LogEventLevel.Debug, rollingInterval: RollingInterval.Day,
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