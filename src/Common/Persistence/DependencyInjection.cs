// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services
                .RegisterServices()
                .RegisterRepository()
                .RegisterValidations()
                .AddPersistenceFacade();

            return services;
        }

        /// <summary>
        /// Add persistence facade
        /// </summary>
        private static IServiceCollection AddPersistenceFacade(this IServiceCollection services)
        {
            services.AddScoped<IServiceFacade, ServiceFacade>();
            services.AddTransient<IValidatorFacade, ValidatorFacade>();
            return services;
        }

        /// <summary>
        /// Register repository (dependency injection)
        /// </summary>
        private static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        /// <summary>
        /// Register services (dependency injection)
        /// </summary>
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        /// <summary>
        /// Register validations (dependency injection)
        /// </summary>
        private static IServiceCollection RegisterValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserModel>, UserValidator>();
            services.AddTransient<IValidator<ProductModel>, ProductValidator>();

            return services;
        }
    }
}
