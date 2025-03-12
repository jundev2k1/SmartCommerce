// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<Notification, bool>> GetNotificationFilters(NotificationFilterModel input)
		{
			var predicate = PredicateBuilder.True<Notification>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(p => p.Id.ToString().Contains(input.Keywords)
					|| p.Title.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(u => u.BranchId.Equals(input.BranchId));
			}

			return predicate;
		}
	}
}
