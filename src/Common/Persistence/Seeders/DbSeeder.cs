// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Seeders
{
	internal class DbSeeder : IDbSeeder
	{
		private readonly ApplicationDBContext _dbContext;
		public DbSeeder(ApplicationDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Seed()
		{
			BranchSeeder.Seed(_dbContext);
			UserSeeder.Seed(_dbContext);
			RoleSeeder.Seed(_dbContext);
			MailTemplateSeeder.Seed(_dbContext);
		}
	}
}
