// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<Category, bool>> GetCategoryFilters(CategoryFilterModel input)
		{
			var predicate = PredicateBuilder.New<Category>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(cate => cate.CategoryId.Contains(input.Keywords)
					|| cate.CategoryName.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(cate => cate.BranchId.Equals(input.BranchId));
			}

			if (string.IsNullOrEmpty(input.CategoryId) == false)
			{
				predicate.And(cate => cate.CategoryId.StartsWith(input.CategoryId));
			}

			if (string.IsNullOrEmpty(input.CategoryName) == false)
			{
				predicate.And(cate => cate.CategoryName.Contains(input.CategoryName));
			}

			if (string.IsNullOrEmpty(input.ParentCategoryId) == false)
			{
				predicate.And(cate => cate.ParentCategoryId.Contains(input.ParentCategoryId));
			}

			if (string.IsNullOrEmpty(input.CreatedBy) == false)
			{
				predicate.And(cate => cate.CreatedBy.Equals(input.CreatedBy));
			}

			if (input.DateCreatedFrom.HasValue) predicate.And(cate => cate.DateCreated >= input.DateCreatedFrom);
			if (input.DateCreatedTo.HasValue) predicate.And(cate => cate.DateCreated <= input.DateCreatedTo);

			if (input.DateChangedFrom.HasValue) predicate.And(cate => cate.DateChanged >= input.DateChangedFrom);
			if (input.DateChangedTo.HasValue) predicate.And(cate => cate.DateChanged <= input.DateChangedTo);

			if (input.Status.HasValue) predicate.And(cate => cate.Status == input.Status);

			return predicate;
		}
	}
}
