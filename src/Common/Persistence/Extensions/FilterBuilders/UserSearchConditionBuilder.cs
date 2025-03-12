// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<User, bool>> GetUserFilters(UserFilterModel input)
		{
			var predicate = PredicateBuilder.New<User>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(user => user.UserId.Contains(input.Keywords)
					|| (user.FirstName.StartsWith(input.Keywords) || user.LastName.StartsWith(input.Keywords))
					|| user.Email.StartsWith(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(user => user.BranchId.Equals(input.BranchId));
			}

			if (string.IsNullOrEmpty(input.UserId) == false)
			{
				predicate.And(user => user.UserId.StartsWith(input.UserId));
			}

			if (string.IsNullOrEmpty(input.UserName) == false)
			{
				predicate.And(user => user.UserName.StartsWith(input.UserName));
			}

			if (string.IsNullOrEmpty(input.FirstName) == false)
			{
				predicate.And(user => user.FirstName.Contains(input.FirstName));
			}

			if (string.IsNullOrEmpty(input.LastName) == false)
			{
				predicate.And(user => user.LastName.Contains(input.LastName));
			}

			if (string.IsNullOrEmpty(input.Email) == false)
			{
				predicate.And(user => user.Email.Contains(input.Email));
			}

			if (string.IsNullOrEmpty(input.PhoneNumber) == false)
			{
				predicate.And(user => user.PhoneNumber.Contains(input.PhoneNumber));
			}

			if (string.IsNullOrEmpty(input.Address1) == false)
			{
				predicate.And(user => user.Address1.Contains(input.Address1));
			}

			if (string.IsNullOrEmpty(input.Address2) == false)
			{
				predicate.And(user => user.Address2.Contains(input.Address2));
			}

			if (string.IsNullOrEmpty(input.Address3) == false)
			{
				predicate.And(user => user.Address3.Contains(input.Address3));
			}

			if (string.IsNullOrEmpty(input.Address4) == false)
			{
				predicate.And(user => user.Address4.Contains(input.Address4));
			}

			if (string.IsNullOrEmpty(input.CreatedBy) == false)
			{
				predicate.And(user => user.CreatedBy.Equals(input.CreatedBy));
			}

			if (input.MinAge > 0) predicate.And(user => input.MinAge <= CommonUtility.CalculateTime(user.Birthday).Years);
			if (input.MaxAge > 0) predicate.And(user => input.MaxAge >= CommonUtility.CalculateTime(user.Birthday).Years);

			predicate.And(user => user.Status.Equals(input.Status));
			predicate.And(user => user.DelFlg.Equals(input.DelFlg));

			if (input.BirthdayFrom.HasValue) predicate.And(user => input.BirthdayFrom >= user.Birthday);
			if (input.BirthdayTo.HasValue) predicate.And(user => input.BirthdayTo <= user.Birthday);

			if (input.DateCreatedFrom.HasValue) predicate.And(user => user.DateCreated >= input.DateCreatedFrom);
			if (input.DateCreatedTo.HasValue) predicate.And(user => user.DateCreated <= input.DateCreatedTo);

			if (input.DateChangedFrom.HasValue) predicate.And(user => user.DateChanged <= input.DateCreatedFrom);
			if (input.DateChangedTo.HasValue) predicate.And(user => user.DateChanged >= input.DateCreatedTo);

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
