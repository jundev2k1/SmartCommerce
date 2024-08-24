// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace ErpManager.Persistence.Extensions.FilterBuilders
{
	public partial class FilterConditionBuilder
	{
		public static Expression<Func<Category, bool>> GetCategoryFilters(CategoryFilterModel filter)
		{
			var predicate = PredicateBuilder.New<Category>();

			if (string.IsNullOrEmpty(filter.Keywords) == false)
			{
				predicate.And(cate => cate.CategoryId.Contains(filter.Keywords)
					|| cate.CategoryName.Contains(filter.Keywords));
			}

			if (string.IsNullOrEmpty(filter.BranchId) == false)
			{
				predicate.And(cate => cate.BranchId.Equals(filter.BranchId));
			}

			if (string.IsNullOrEmpty(filter.CategoryId) == false)
			{
				predicate.And(cate => cate.CategoryId.StartsWith(filter.CategoryId));
			}

			if (string.IsNullOrEmpty(filter.CategoryName) == false)
			{
				predicate.And(cate => cate.CategoryName.Contains(filter.CategoryName));
			}

			if (string.IsNullOrEmpty(filter.ParentCategoryId) == false)
			{
				predicate.And(cate => cate.ParentCategoryId.Contains(filter.ParentCategoryId));
			}

			if (string.IsNullOrEmpty(filter.CreatedBy) == false)
			{
				predicate.And(cate => cate.CreatedBy.Equals(filter.CreatedBy));
			}

			if (filter.DateCreatedFrom.HasValue) predicate.And(cate => cate.DateCreated >= filter.DateCreatedFrom);
			if (filter.DateCreatedTo.HasValue) predicate.And(cate => cate.DateCreated <= filter.DateCreatedTo);

			if (filter.DateChangedFrom.HasValue) predicate.And(cate => cate.DateChanged >= filter.DateChangedFrom);
			if (filter.DateChangedTo.HasValue) predicate.And(cate => cate.DateChanged <= filter.DateChangedTo);

			if (filter.Status.HasValue) predicate.And(cate => cate.Status == filter.Status);

			return predicate;
		}
	}
}
