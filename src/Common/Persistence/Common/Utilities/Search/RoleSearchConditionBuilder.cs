// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618

namespace ErpManager.Persistence.Common.Utilities.Search
{
	public partial class SearchConditionBuilder
	{
		public static Expression<Func<Role, bool>> RoleSearch(RoleSearchDto searchDto)
		{
			var predicate = PredicateBuilder.True<Role>();

			if (string.IsNullOrEmpty(searchDto.Keywords) == false)
			{
				predicate.And(p =>
					p.RoleId.ToString().Contains(searchDto.Keywords)
					|| p.Name.Contains(searchDto.Keywords));
			}

			if (string.IsNullOrEmpty(searchDto.BranchId) == false)
			{
				predicate.And(u => u.BranchId.Contains(searchDto.BranchId));
			}

			return predicate;
		}
	}
}
