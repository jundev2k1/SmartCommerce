// Copyright (c) 2025 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<ProductCategory, bool>> GetCategoryFilters(ProductCategoryFilterModel input)
		{
			var predicate = PredicateBuilder.New<ProductCategory>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(cate => cate.CategoryId.Contains(input.Keywords)
					|| cate.Name.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(cate => cate.BranchId.Equals(input.BranchId));
			}

			if (string.IsNullOrEmpty(input.CategoryId) == false)
			{
				predicate.And(cate => cate.CategoryId.StartsWith(input.CategoryId));
			}

			if (string.IsNullOrEmpty(input.Name) == false)
			{
				predicate.And(cate => cate.Name.Contains(input.Name));
			}

			if (string.IsNullOrEmpty(input.ParentId) == false)
			{
				predicate.And(cate => cate.ParentId.Contains(input.ParentId));
			}

			if (string.IsNullOrEmpty(input.CreatedBy) == false)
			{
				predicate.And(cate => cate.CreatedBy.Equals(input.CreatedBy));
			}

			if (input.DateCreatedFrom.HasValue) predicate.And(cate => cate.DateCreated >= input.DateCreatedFrom);
			if (input.DateCreatedTo.HasValue) predicate.And(cate => cate.DateCreated <= input.DateCreatedTo);

			if (input.DateChangedFrom.HasValue) predicate.And(cate => cate.DateChanged >= input.DateChangedFrom);
			if (input.DateChangedTo.HasValue) predicate.And(cate => cate.DateChanged <= input.DateChangedTo);

			return predicate;
		}
	}
}
