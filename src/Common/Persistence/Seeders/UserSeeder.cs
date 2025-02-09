// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Seeders
{
	internal sealed class UserSeeder
	{
		public static void Seed(ApplicationDBContext context)
		{
			var needExecute = context.Users.Any(user =>
				(user.BranchId == Constants.CONFIG_MASTER_BRANCH_ID)
				&& (user.UserId == Constants.CONFIG_MASTER_OPERATOR_ID)) == false;
			if (needExecute == false) return;

			// Create operator if not exist
			SeedList.ForEach(user => context.Add(user));
			context.SaveChanges();
		}

		private static List<User> SeedList = new List<User>()
		{
			// ERP administrator
			new User()
			{
				BranchId = Constants.CONFIG_MASTER_BRANCH_ID,
				UserId = Constants.CONFIG_MASTER_OPERATOR_ID,
				UserName = Constants.CONFIG_MASTER_OPERATOR_USERNAME,
				Password = Authentication.Instance.PasswordEncrypt(Constants.CONFIG_MASTER_OPERATOR_PASSWORD),
				Email = Constants.CONFIG_OWNER_MAIL,
				PhoneNumber = Constants.CONFIG_OWNER_TEL,
				FirstName = Constants.CONFIG_OWNER_NAME,
				Address1 = "047",
				Address2 = "047001",
				Address3 = "047001008",
				Address4 = "",
				Avatar = "",
				Sex = UserSexEnum.Male,
				Birthday = new DateTime(2000, 1, 1),
				CreatedBy = "System",
				DateCreated = DateTime.Now,
				DateChanged = DateTime.Now,
				RoleId = 1,
				DelFlg = false
			},
		};
	}
}
