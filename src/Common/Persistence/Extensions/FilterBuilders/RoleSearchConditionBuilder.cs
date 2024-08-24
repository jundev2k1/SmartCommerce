// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace ErpManager.Persistence.Extensions.FilterBuilders
{
	public partial class FilterConditionBuilder
	{
		public static Expression<Func<Role, bool>> GetRoleFilters(RoleFilterModel searchDto)
		{
			var predicate = PredicateBuilder.New<Role>();

			if (string.IsNullOrEmpty(searchDto.Keywords) == false)
			{
				predicate.And(role =>
					role.RoleId.ToString().Contains(searchDto.Keywords)
					|| role.Name.Contains(searchDto.Keywords));
			}

			if (string.IsNullOrEmpty(searchDto.BranchId) == false)
			{
				predicate.And(role => role.BranchId.Equals(searchDto.BranchId));
			}

			return predicate;
		}
	}
}
