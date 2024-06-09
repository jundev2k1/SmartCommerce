// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Infrastructure.Logging;
using ErpManager.Infrastructure.Mail;
using Microsoft.AspNetCore.Builder;

namespace ErpManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDependencyInjection();
            return services;
        }

        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IFileLogger, FileLogger>();
            services.AddSingleton<IMailSender, MailSender>();
            return services;
        }

        public static IApplicationBuilder UseInfrastructureMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SessionCheckMiddleware>();
            return app;
        }
    }
}