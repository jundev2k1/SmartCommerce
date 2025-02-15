// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Application.Features.Products.Queries.GetProduct
{
	public sealed class GetProductQuery : IRequest<ProductModel?>
	{
		public GetProductQuery()
		{
		}

		public string BrandID { get; set; } = string.Empty;
		public string ProductID { get; set; } = string.Empty;
	}
}
