using Domain.Repositories.User;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add persistence
        /// </summary>
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services
                .AddServices()
                .AddRepositories()
                .AddValidator();

            return services;
        }

        /// <summary>
        /// Add services
        /// </summary>
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Dependency injection service
            services.AddScoped<IUserService, UserService>();
            return services;
        }

        /// <summary>
        /// Add repositories
        /// </summary>
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Dependency injection repository
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        /// <summary>
        /// Add validator
        /// </summary>
        private static IServiceCollection AddValidator(this IServiceCollection services)
        {
            return services;
        }
    }
}
