// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<User, bool>> GetUserFilters(UserFilterModel searchCondition)
		{
			var predicate = PredicateBuilder.New<User>();

			if (string.IsNullOrEmpty(searchCondition.Keywords) == false)
			{
				predicate.And(user => user.UserId.Contains(searchCondition.Keywords)
					|| (user.FirstName.StartsWith(searchCondition.Keywords) || user.LastName.StartsWith(searchCondition.Keywords))
					|| user.Email.StartsWith(searchCondition.Keywords));
			}

			if (string.IsNullOrEmpty(searchCondition.BranchId) == false)
			{
				predicate.And(user => user.BranchId.Equals(searchCondition.BranchId));
			}

			if (string.IsNullOrEmpty(searchCondition.UserId) == false)
			{
				predicate.And(user => user.UserId.StartsWith(searchCondition.UserId));
			}

			if (string.IsNullOrEmpty(searchCondition.UserName) == false)
			{
				predicate.And(user => user.UserName.StartsWith(searchCondition.UserName));
			}

			if (string.IsNullOrEmpty(searchCondition.FirstName) == false)
			{
				predicate.And(user => user.FirstName.Contains(searchCondition.FirstName));
			}

			if (string.IsNullOrEmpty(searchCondition.LastName) == false)
			{
				predicate.And(user => user.LastName.Contains(searchCondition.LastName));
			}

			if (string.IsNullOrEmpty(searchCondition.Email) == false)
			{
				predicate.And(user => user.Email.Contains(searchCondition.Email));
			}

			if (string.IsNullOrEmpty(searchCondition.PhoneNumber) == false)
			{
				predicate.And(user => user.PhoneNumber.Contains(searchCondition.PhoneNumber));
			}

			if (string.IsNullOrEmpty(searchCondition.Address1) == false)
			{
				predicate.And(user => user.Address1.Contains(searchCondition.Address1));
			}

			if (string.IsNullOrEmpty(searchCondition.Address2) == false)
			{
				predicate.And(user => user.Address2.Contains(searchCondition.Address2));
			}

			if (string.IsNullOrEmpty(searchCondition.Address3) == false)
			{
				predicate.And(user => user.Address3.Contains(searchCondition.Address3));
			}

			if (string.IsNullOrEmpty(searchCondition.Address4) == false)
			{
				predicate.And(user => user.Address4.Contains(searchCondition.Address4));
			}

			if (string.IsNullOrEmpty(searchCondition.CreatedBy) == false)
			{
				predicate.And(user => user.CreatedBy.Equals(searchCondition.CreatedBy));
			}

			if (searchCondition.MinAge > 0) predicate.And(user => searchCondition.MinAge <= CommonUtility.CalculateTime(user.Birthday).Years);
			if (searchCondition.MaxAge > 0) predicate.And(user => searchCondition.MaxAge >= CommonUtility.CalculateTime(user.Birthday).Years);

			predicate.And(user => user.Status.Equals(searchCondition.Status));
			predicate.And(user => user.DelFlg.Equals(searchCondition.DelFlg));

			if (searchCondition.BirthdayFrom.HasValue) predicate.And(user => searchCondition.BirthdayFrom >= user.Birthday);
			if (searchCondition.BirthdayTo.HasValue) predicate.And(user => searchCondition.BirthdayTo <= user.Birthday);

			if (searchCondition.DateCreatedFrom.HasValue) predicate.And(user => user.DateCreated >= searchCondition.DateCreatedFrom);
			if (searchCondition.DateCreatedTo.HasValue) predicate.And(user => user.DateCreated <= searchCondition.DateCreatedTo);

			if (searchCondition.DateChangedFrom.HasValue) predicate.And(user => user.DateChanged <= searchCondition.DateCreatedFrom);
			if (searchCondition.DateChangedTo.HasValue) predicate.And(user => user.DateChanged >= searchCondition.DateCreatedTo);

			return predicate;
		}

		public static IOrderedQueryable<User> OrderByDynamic(
			this IQueryable<User> query,
			UserFilterModel searchCondition)
		{
			IOrderedQueryable<User> OrderByDynamic<T>(Expression<Func<User, T>> selector)
			{
				var isAscending = searchCondition.OrderByDirection == Constants.FLG_ORDER_BY_ASCENDING;
				return isAscending
					? query.OrderBy(selector)
					: query.OrderByDescending(selector);
			}

			switch (searchCondition.OrderBy)
			{
				case Constants.FLG_ORDER_BY_USER_USER_ID:
					return OrderByDynamic<string>(model => model.UserId);

				case Constants.FLG_ORDER_BY_USER_NAME:
					return OrderByDynamic<string>(model => model.FirstName)
						.ThenBy(model => model.LastName);

				case Constants.FLG_ORDER_BY_USER_EMAIL:
					return OrderByDynamic<string>(model => model.Email);

				case Constants.FLG_ORDER_BY_USER_SEX:
					return OrderByDynamic<UserSexEnum>(model => model.Sex);

				case Constants.FLG_ORDER_BY_USER_STATUS:
					return OrderByDynamic<UserStatusEnum>(model => model.Status);

				default:
					return OrderByDynamic<DateTime?>(model => model.DateCreated);
			}
		}
	}
}
