// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<Member, bool>> GetMemberFilters(MemberFilterModel input)
		{
			var predicate = PredicateBuilder.True<Member>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(p => p.MemberId.StartsWith(input.Keywords)
					|| $"{p.FirstName} {p.LastName}".Contains(input.Keywords)
					|| p.FirstName.Contains(input.Keywords)
					|| p.LastName.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(u => u.BranchId.Equals(input.BranchId));
			}

			if (string.IsNullOrEmpty(input.MemberId) == false)
			{
				predicate.And(u => u.MemberId.StartsWith(input.MemberId));
			}

			if (string.IsNullOrEmpty(input.FirstName) == false)
			{
				predicate.And(u => u.FirstName.Contains(input.FirstName));
			}

			if (string.IsNullOrEmpty(input.LastName) == false)
			{
				predicate.And(u => u.LastName.Contains(input.LastName));
			}

			if (string.IsNullOrEmpty(input.Email) == false)
			{
				predicate.And(u => u.Email.Contains(input.Email));
			}

			if (string.IsNullOrEmpty(input.CardNumber) == false)
			{
				predicate.And(u => u.CardNumber.StartsWith(input.CardNumber));
			}

			if (string.IsNullOrEmpty(input.PhoneNumber) == false)
			{
				predicate.And(u => u.PhoneNumber.Contains(input.PhoneNumber)
					|| u.BackupPhoneNumber.Contains(input.PhoneNumber));
			}

			if (string.IsNullOrEmpty(input.Address1) == false)
			{
				predicate.And(u => u.Address1.Contains(input.Address1)
					|| u.SubAddress1.Contains(input.Address1));
			}

			if (string.IsNullOrEmpty(input.Address2) == false)
			{
				predicate.And(u => u.Address2.Contains(input.Address2)
					|| u.SubAddress2.Contains(input.Address2));
			}

			if (string.IsNullOrEmpty(input.Address3) == false)
			{
				predicate.And(u => u.Address3.Contains(input.Address3)
					|| u.SubAddress3.Contains(input.Address3));
			}

			if (string.IsNullOrEmpty(input.Address4) == false)
			{
				predicate.And(u => u.Address4.Contains(input.Address4)
					|| u.SubAddress4.Contains(input.Address4));
			}

			if (string.IsNullOrEmpty(input.CreatedBy) == false)
			{
				predicate.And(u => u.CreatedBy.Equals(input.CreatedBy));
			}

			if (input.MinAge > 0) predicate.And(u => input.MinAge <= CommonUtility.CalculateTime(u.Birthday).Years);
			if (input.MaxAge > 0) predicate.And(u => input.MaxAge >= CommonUtility.CalculateTime(u.Birthday).Years);

			predicate.And(u => u.Status.Equals(input.Status));
			predicate.And(u => u.DelFlg.Equals(input.DelFlg));

			if (input.BirthdayFrom.HasValue) predicate.And(u => input.BirthdayFrom >= u.Birthday);
			if (input.BirthdayTo.HasValue) predicate.And(u => input.BirthdayTo <= u.Birthday);

			if (input.DateCreatedFrom.HasValue) predicate.And(u => u.DateCreated >= input.DateCreatedFrom);
			if (input.DateCreatedTo.HasValue) predicate.And(u => u.DateCreated <= input.DateCreatedTo);

			if (input.DateChangedFrom.HasValue) predicate.And(u => u.DateChanged <= input.DateCreatedFrom);
			if (input.DateChangedTo.HasValue) predicate.And(u => u.DateChanged >= input.DateCreatedTo);

			return predicate;
		}
	}
}
