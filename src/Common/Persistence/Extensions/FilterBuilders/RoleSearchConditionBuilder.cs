// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<Role, bool>> GetRoleFilters(RoleFilterModel input)
		{
			var predicate = PredicateBuilder.New<Role>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(role =>
					role.RoleId.ToString().Contains(input.Keywords)
					|| role.Name.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(role => role.BranchId.Equals(input.BranchId));
			}

			return predicate;
		}
	}
}
