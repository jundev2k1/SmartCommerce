// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Seeders
{
	internal class DbSeeder : IDbSeeder
	{
		private readonly DBContext _dbContext;
		public DbSeeder(DBContext dbContext)
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
