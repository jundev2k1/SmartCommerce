using ErpManager.Infrastructure.Common.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ErpManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
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