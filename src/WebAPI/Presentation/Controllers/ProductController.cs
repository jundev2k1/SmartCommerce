// Copyright (c) 2024 - Jun Dev. All rights reserved

using SmartCommerce.Application.Features.Products.Queries.GetByCriteria;
using SmartCommerce.Application.Features.Products.Queries.GetProduct;

namespace SmartCommerce.WebAPI.Controllers
{
	[ApiController]
	public sealed class ProductController(ISender seeder) : BaseController
	{
		private readonly ISender _seeder = seeder;

		[HttpPost("getByCriteria")]
		public async Task<IActionResult> GetByCriteria(
			[FromBody] ProductFilterModel searchParams,
			[FromQuery] int pageIndex = 1,
			[FromQuery] int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			searchParams.PageNumber = pageIndex;
			searchParams.PageSize = pageSize;
			var query = new GetByCriteriaQuery(searchParams);
			var response = await _seeder.Send(query);
			return Ok(response);
		}

		[HttpGet("get")]
		public async Task<IActionResult> Get(string branchId, string productId)
		{
			var query = new GetProductQuery
			{
				BrandID = branchId,
				ProductID = productId,
			};
			var response = await _seeder.Send(query);
			return Ok(response);
		}
	}
}
