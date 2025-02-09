// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public partial class FilterConditionBuilder
	{
		public static Expression<Func<Product, bool>> GetProductFilters(ProductFilterModel searchDto)
		{
			var predicate = PredicateBuilder.New<Product>();

			if (string.IsNullOrEmpty(searchDto.Keywords) == false)
			{
				predicate.And(p => p.ProductId.Contains(searchDto.Keywords)
					|| p.Name.Contains(searchDto.Keywords));
			}

			if (string.IsNullOrEmpty(searchDto.BranchId) == false)
			{
				predicate.And(p => p.BranchId.Equals(searchDto.BranchId));
			}

			if (string.IsNullOrEmpty(searchDto.ProductId) == false)
			{
				predicate.And(p => p.ProductId.StartsWith(searchDto.ProductId));
			}

			if (string.IsNullOrEmpty(searchDto.ProductName) == false)
			{
				predicate.And(p => p.Name.Contains(searchDto.ProductName));
			}

			if (string.IsNullOrEmpty(searchDto.Address1) == false)
			{
				predicate.And(p => p.Address1.Contains(searchDto.Address1));
			}

			if (string.IsNullOrEmpty(searchDto.Address2) == false)
			{
				predicate.And(p => p.Address2.Contains(searchDto.Address2));
			}

			if (string.IsNullOrEmpty(searchDto.Address3) == false)
			{
				predicate.And(p => p.Address3.Contains(searchDto.Address3));
			}

			if (string.IsNullOrEmpty(searchDto.Address4) == false)
			{
				predicate.And(p => p.Address4.Contains(searchDto.Address4));
			}

			if (string.IsNullOrEmpty(searchDto.TakeOverId) == false)
			{
				predicate.And(p => p.TakeOverId.Equals(searchDto.TakeOverId));
			}

			if (string.IsNullOrEmpty(searchDto.CreatedBy) == false)
			{
				predicate.And(p => p.CreatedBy.Equals(searchDto.CreatedBy));
			}

			if (searchDto.DisplayPrice.HasValue) predicate.And(p => p.DisplayPrice.Equals(searchDto.DisplayPrice));

			if (searchDto.MinSize1.HasValue) predicate.And(p => p.Size1 >= searchDto.MinSize1);
			if (searchDto.MaxSize1.HasValue) predicate.And(p => p.Size1 <= searchDto.MaxSize1);

			if (searchDto.MinSize2.HasValue) predicate.And(p => p.Size2 >= searchDto.MinSize2);
			if (searchDto.MaxSize2.HasValue) predicate.And(p => p.Size2 <= searchDto.MaxSize2);

			if (searchDto.MinSize3.HasValue) predicate.And(p => p.Size3 >= searchDto.MinSize3);
			if (searchDto.MaxSize3.HasValue) predicate.And(p => p.Size3 <= searchDto.MaxSize3);

			if (searchDto.MinPrice1.HasValue) predicate.And(p => p.Price1 >= searchDto.MinPrice1);
			if (searchDto.MaxPrice1.HasValue) predicate.And(p => p.Price1 <= searchDto.MaxPrice1);

			if (searchDto.MinPrice2.HasValue) predicate.And(p => p.Price2 >= searchDto.MinPrice2);
			if (searchDto.MaxPrice2.HasValue) predicate.And(p => p.Price2 <= searchDto.MaxPrice2);

			if (searchDto.MinPrice3.HasValue) predicate.And(p => p.Price3 >= searchDto.MinPrice3);
			if (searchDto.MaxPrice3.HasValue) predicate.And(p => p.Price3 <= searchDto.MaxPrice3);

			if (searchDto.DateCreatedFrom.HasValue) predicate.And(p => p.DateCreated >= searchDto.DateCreatedFrom);
			if (searchDto.DateCreatedTo.HasValue) predicate.And(p => p.DateCreated <= searchDto.DateCreatedTo);

			if (searchDto.DateChangedFrom.HasValue) predicate.And(p => p.DateChanged >= searchDto.DateChangedFrom);
			if (searchDto.DateChangedTo.HasValue) predicate.And(p => p.DateChanged <= searchDto.DateChangedTo);

			if (searchDto.Status.HasValue) predicate.And(p => p.Status == searchDto.Status);

			predicate.And(p => p.DelFlg == searchDto.DelFlg);

			return predicate;
		}
	}
}
