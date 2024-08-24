// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace ErpManager.Persistence.Extensions.FilterBuilders
{
	public partial class FilterConditionBuilder
	{
		public static Expression<Func<Notification, bool>> GetNotificationFilters(NotificationFilterModel searchDto)
		{
			var predicate = PredicateBuilder.True<Notification>();

			if (string.IsNullOrEmpty(searchDto.Keywords) == false)
			{
				predicate.And(p => p.Id.ToString().Contains(searchDto.Keywords)
					|| p.Title.Contains(searchDto.Keywords));
			}

			if (string.IsNullOrEmpty(searchDto.BranchId) == false)
			{
				predicate.And(u => u.BranchId.Equals(searchDto.BranchId));
			}

			return predicate;
		}
	}
}
