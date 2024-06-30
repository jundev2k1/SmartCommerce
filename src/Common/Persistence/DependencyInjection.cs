// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Builder;

namespace ErpManager.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services)
		{
			services
				.RegisterServices()
				.RegisterRepository()
				.AddUtility();

			return services;
		}

		/// <summary>
		/// Add singleton
		/// </summary>
		private static IServiceCollection AddUtility(this IServiceCollection services)
		{
			services.AddScoped<IServiceFacade, ServiceFacade>();
			services.AddScoped<IDbSeeder, DbSeeder>();
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
			services.AddScoped<ITokenRepository, TokenRepository>();
			services.AddScoped<IMemberRepository, MemberRepository>();
			services.AddScoped<IMailTemplateRepository, MailTemplateRepository>();

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
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IMemberService, MemberService>();
			services.AddScoped<IMailTemplateService, MailTemplateService>();

			return services;
		}

		public static IApplicationBuilder UsePersistence(this IApplicationBuilder app)
		{
			// Add database seeder
			using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var seeder = scope.ServiceProvider.GetService<IDbSeeder>();
				seeder.Seed();
			}

			return app;
		}
	}
}
