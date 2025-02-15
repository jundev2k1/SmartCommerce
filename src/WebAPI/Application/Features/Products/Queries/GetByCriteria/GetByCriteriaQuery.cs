// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Application.Features.Products.Queries.GetByCriteria
{
	public sealed class GetByCriteriaQuery : IRequest<SearchResultModel<ProductModel>>
	{
		public GetByCriteriaQuery(ProductFilterModel condition)
		{
			SearchCondition = condition;
		}

		public ProductFilterModel SearchCondition { get; }
		public int PageNumber => SearchCondition.PageNumber;
		public int PageSize => SearchCondition.PageSize;
	}
}
