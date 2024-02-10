// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Persistence.Repositories.Role;
using ErpManager.Persistence.Repositories.User;

namespace ErpManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services
                .RegisterServices()
                .RegisterRepository()
                .AddPersistenceFacade();

            return services;
        }

        /// <summary>
        /// Add persistence facade
        /// </summary>
        private static IServiceCollection AddPersistenceFacade(this IServiceCollection services)
        {
            services.AddScoped<IServices, ServiceList>();
            return services;
        }

        /// <summary>
        /// Register repository (dependency injection)
        /// </summary>
        private static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        /// <summary>
        /// Register services (dependency injection)
        /// </summary>
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
