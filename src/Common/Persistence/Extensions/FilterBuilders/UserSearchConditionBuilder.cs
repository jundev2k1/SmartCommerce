// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace ErpManager.Persistence.Extensions.FilterBuilders
{
	public partial class FilterConditionBuilder
	{
		public static Expression<Func<User, bool>> GetUserFilters(UserFilterModel searchDto)
		{
			var predicate = PredicateBuilder.New<User>();

			if (string.IsNullOrEmpty(searchDto.Keywords) == false)
			{
				predicate.And(user => user.UserId.Contains(searchDto.Keywords)
					|| (user.FirstName.StartsWith(searchDto.Keywords) || user.LastName.StartsWith(searchDto.Keywords))
					|| user.Email.StartsWith(searchDto.Keywords));
			}

			if (string.IsNullOrEmpty(searchDto.BranchId) == false)
			{
				predicate.And(user => user.BranchId.Equals(searchDto.BranchId));
			}

			if (string.IsNullOrEmpty(searchDto.UserId) == false)
			{
				predicate.And(user => user.UserId.StartsWith(searchDto.UserId));
			}

			if (string.IsNullOrEmpty(searchDto.UserName) == false)
			{
				predicate.And(user => user.UserName.StartsWith(searchDto.UserName));
			}

			if (string.IsNullOrEmpty(searchDto.FirstName) == false)
			{
				predicate.And(user => user.FirstName.Contains(searchDto.FirstName));
			}

			if (string.IsNullOrEmpty(searchDto.LastName) == false)
			{
				predicate.And(user => user.LastName.Contains(searchDto.LastName));
			}

			if (string.IsNullOrEmpty(searchDto.Email) == false)
			{
				predicate.And(user => user.Email.Contains(searchDto.Email));
			}

			if (string.IsNullOrEmpty(searchDto.PhoneNumber) == false)
			{
				predicate.And(user => user.PhoneNumber.Contains(searchDto.PhoneNumber));
			}

			if (string.IsNullOrEmpty(searchDto.Address1) == false)
			{
				predicate.And(user => user.Address1.Contains(searchDto.Address1));
			}

			if (string.IsNullOrEmpty(searchDto.Address2) == false)
			{
				predicate.And(user => user.Address2.Contains(searchDto.Address2));
			}

			if (string.IsNullOrEmpty(searchDto.Address3) == false)
			{
				predicate.And(user => user.Address3.Contains(searchDto.Address3));
			}

			if (string.IsNullOrEmpty(searchDto.Address4) == false)
			{
				predicate.And(user => user.Address4.Contains(searchDto.Address4));
			}

			if (string.IsNullOrEmpty(searchDto.CreatedBy) == false)
			{
				predicate.And(user => user.CreatedBy.Equals(searchDto.CreatedBy));
			}

			if (searchDto.MinAge > 0) predicate.And(user => searchDto.MinAge <= CommonUtility.CalculateTime(user.Birthday).Years);
			if (searchDto.MaxAge > 0) predicate.And(user => searchDto.MaxAge >= CommonUtility.CalculateTime(user.Birthday).Years);

			predicate.And(user => user.Status.Equals(searchDto.Status));
			predicate.And(user => user.DelFlg.Equals(searchDto.DelFlg));

			if (searchDto.BirthdayFrom.HasValue) predicate.And(user => searchDto.BirthdayFrom >= user.Birthday);
			if (searchDto.BirthdayTo.HasValue) predicate.And(user => searchDto.BirthdayTo <= user.Birthday);

			if (searchDto.DateCreatedFrom.HasValue) predicate.And(user => user.DateCreated >= searchDto.DateCreatedFrom);
			if (searchDto.DateCreatedTo.HasValue) predicate.And(user => user.DateCreated <= searchDto.DateCreatedTo);

			if (searchDto.DateChangedFrom.HasValue) predicate.And(user => user.DateChanged <= searchDto.DateCreatedFrom);
			if (searchDto.DateChangedTo.HasValue) predicate.And(user => user.DateChanged >= searchDto.DateCreatedTo);

			return predicate;
		}
	}
}
