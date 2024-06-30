// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Seeders
{
	internal sealed class RoleSeeder
	{
		public static void Seed(DBContext context)
		{
			var needExecute = context.Roles.Any(role =>
				role.BranchId == Constants.CONFIG_MASTER_BRANCH_ID) == false;
			if (needExecute == false) return;

			// Create admin role if not exist
			SeedList.ForEach(role => context.Add(role));
			context.SaveChanges();
		}

		private static List<Role> SeedList = new List<Role>()
		{
            // ERP admin role
            new Role()
			{
				BranchId = Constants.CONFIG_MASTER_BRANCH_ID,
				Name = "Administrator",
				Permission = "9999",
				Priority = 1,
				Status = RoleStatusEnum.Active,
				CreatedBy = "System",
				DateCreated = DateTime.Now,
			},
		};
	}
}
