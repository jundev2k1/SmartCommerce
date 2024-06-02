using ErpManager.Infrastructure.Common.Middleware;
using ErpManager.Infrastructure.Upload;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
            return services;
        }

        public static IApplicationBuilder UseInfrastructureMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<SessionCheckMiddleware>();
            return app;
        }
    }
}