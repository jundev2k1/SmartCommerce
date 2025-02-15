// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Application.Features.Products.Queries.GetByCriteria
{
	public sealed class GetByCriteriaHandler
		: IRequestHandler<GetByCriteriaQuery, SearchResultModel<ProductModel>>
	{
		private readonly IServiceFacade _serviceFacade;

		public GetByCriteriaHandler(IServiceFacade serviceFacade)
		{
			_serviceFacade = serviceFacade;
		}

		public async Task<SearchResultModel<ProductModel>> Handle(
			GetByCriteriaQuery request,
			CancellationToken cancellation)
		{
			return await _serviceFacade.Products.GetByCriteriaAsync(
				request.SearchCondition,
				request.PageNumber,
				request.PageSize);
		}
	}
}
