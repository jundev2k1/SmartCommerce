// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Seeders
{
	internal sealed class BranchSeeder
	{
		public static void Seed(ApplicationDBContext context)
		{
			var needExecute = context.Branches.Any(user =>
				user.BranchId == Constants.CONFIG_MASTER_BRANCH_ID) == false;
			if (needExecute == false) return;

			// Create branch if not exist
			SeedList.ForEach(user => context.Add(user));
			context.SaveChanges();
		}

		private static List<Branch> SeedList = new List<Branch>()
		{
            // Main branch
            new Branch()
			{
				BranchId = Constants.CONFIG_MASTER_BRANCH_ID,
				Name = "Main Branch",
				Avatar = "",
				Status = BranchStatusEnum.Active,
				DateCreated = DateTime.Now,
			},
		};
	}
}
