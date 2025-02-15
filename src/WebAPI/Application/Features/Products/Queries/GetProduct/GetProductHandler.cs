// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Application.Features.Products.Queries.GetProduct
{
	public sealed class GetProductHandler : IRequestHandler<GetProductQuery, ProductModel?>
	{
		private readonly IServiceFacade _serviceFacade;

		public GetProductHandler(IServiceFacade serviceFacade)
		{
			_serviceFacade = serviceFacade;
		}

		public async Task<ProductModel?> Handle(GetProductQuery request, CancellationToken cancellation)
		{
			return await _serviceFacade.Products.GetAsync(request.BrandID, request.ProductID);
		}
	}
}
