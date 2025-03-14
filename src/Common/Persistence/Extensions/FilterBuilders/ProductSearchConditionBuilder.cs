// Copyright (c) 2024 - Jun Dev. All rights reserved

#pragma warning disable CS0618
using System;

namespace SmartCommerce.Persistence.Extensions.FilterBuilders
{
	public static partial class FilterConditionBuilder
	{
		public static Expression<Func<Product, bool>> GetProductFilters(ProductFilterModel input)
		{
			var predicate = PredicateBuilder.New<Product>();

			if (string.IsNullOrEmpty(input.Keywords) == false)
			{
				predicate.And(p => p.ProductId.Contains(input.Keywords)
					|| p.Name.Contains(input.Keywords));
			}

			if (string.IsNullOrEmpty(input.BranchId) == false)
			{
				predicate.And(p => p.BranchId.Equals(input.BranchId));
			}

			if (string.IsNullOrEmpty(input.ProductId) == false)
			{
				predicate.And(p => p.ProductId.StartsWith(input.ProductId));
			}

			if (string.IsNullOrEmpty(input.ProductName) == false)
			{
				predicate.And(p => p.Name.Contains(input.ProductName));
			}

			if (string.IsNullOrEmpty(input.Address1) == false)
			{
				predicate.And(p => p.Address1.Contains(input.Address1));
			}

			if (string.IsNullOrEmpty(input.Address2) == false)
			{
				predicate.And(p => p.Address2.Contains(input.Address2));
			}

			if (string.IsNullOrEmpty(input.Address3) == false)
			{
				predicate.And(p => p.Address3.Contains(input.Address3));
			}

			if (string.IsNullOrEmpty(input.Address4) == false)
			{
				predicate.And(p => p.Address4.Contains(input.Address4));
			}

			if (string.IsNullOrEmpty(input.TakeOverId) == false)
			{
				predicate.And(p => p.TakeOverId.Equals(input.TakeOverId));
			}

			if (string.IsNullOrEmpty(input.CreatedBy) == false)
			{
				predicate.And(p => p.CreatedBy.Equals(input.CreatedBy));
			}

			if (input.DisplayPrice.HasValue) predicate.And(p => p.DisplayPrice.Equals(input.DisplayPrice));

			if (input.MinSize1.HasValue) predicate.And(p => p.Size1 >= input.MinSize1);
			if (input.MaxSize1.HasValue) predicate.And(p => p.Size1 <= input.MaxSize1);

			if (input.MinSize2.HasValue) predicate.And(p => p.Size2 >= input.MinSize2);
			if (input.MaxSize2.HasValue) predicate.And(p => p.Size2 <= input.MaxSize2);

			if (input.MinSize3.HasValue) predicate.And(p => p.Size3 >= input.MinSize3);
			if (input.MaxSize3.HasValue) predicate.And(p => p.Size3 <= input.MaxSize3);

			if (input.MinPrice1.HasValue) predicate.And(p => p.Price1 >= input.MinPrice1);
			if (input.MaxPrice1.HasValue) predicate.And(p => p.Price1 <= input.MaxPrice1);

			if (input.MinPrice2.HasValue) predicate.And(p => p.Price2 >= input.MinPrice2);
			if (input.MaxPrice2.HasValue) predicate.And(p => p.Price2 <= input.MaxPrice2);

			if (input.MinPrice3.HasValue) predicate.And(p => p.Price3 >= input.MinPrice3);
			if (input.MaxPrice3.HasValue) predicate.And(p => p.Price3 <= input.MaxPrice3);

			if (input.DateCreatedFrom.HasValue) predicate.And(p => p.DateCreated >= input.DateCreatedFrom);
			if (input.DateCreatedTo.HasValue) predicate.And(p => p.DateCreated <= input.DateCreatedTo);

			if (input.DateChangedFrom.HasValue) predicate.And(p => p.DateChanged >= input.DateChangedFrom);
			if (input.DateChangedTo.HasValue) predicate.And(p => p.DateChanged <= input.DateChangedTo);

			if (input.Status.HasValue) predicate.And(p => p.Status == input.Status);

			predicate.And(p => p.DelFlg == input.DelFlg);

			return predicate;
		}

		public static IOrderedQueryable<Product> OrderByDynamic(
			this IQueryable<Product> query,
			ProductFilterModel searchDto)
		{
			IOrderedQueryable<Product> OrderByDynamic<T>(Expression<Func<Product, T>> selector)
			{
				var isAscending = searchDto.OrderByDirection == Constants.FLG_ORDER_BY_ASCENDING;
				return isAscending
					? query.OrderBy(selector)
					: query.OrderByDescending(selector);
			}

			switch (searchDto.OrderBy)
			{
				case Constants.FLG_ORDER_BY_PRODUCT_PRODUCT_ID:
					return OrderByDynamic<string>(model => model.ProductId);

				case Constants.FLG_ORDER_BY_PRODUCT_NAME:
					return OrderByDynamic<string>(model => model.Name);

				case Constants.FLG_ORDER_BY_PRODUCT_PRICE:
					return OrderByDynamic<decimal>(model => model.DisplayPrice == DisplayPriceEnum.Price1
						? model.Price1
						: model.DisplayPrice == DisplayPriceEnum.Price2
							? model.Price2
							: model.DisplayPrice == DisplayPriceEnum.Price3
								? model.Price3
								: model.Price1);

				case Constants.FLG_ORDER_BY_PRODUCT_SALE_STATUS:
					return OrderByDynamic<ProductStatusEnum>(model => model.Status);

				default:
					return OrderByDynamic<DateTime?>(model => model.DateCreated);
			}
		}
	}
}
