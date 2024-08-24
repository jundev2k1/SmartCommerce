// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Domain.Extensions.FilterModels;
using ErpManager.Persistence.Common;

namespace ErpManager.WebAPI.Controllers
{
	[ApiController]
	public sealed class ProductController(IServiceFacade services) : BaseController
	{
		private readonly IServiceFacade _services = services;

		[HttpPost("getByCriteria")]
		public async Task<IActionResult> GetByCriteria(
			[FromBody] ProductFilterModel searchParams,
			[FromQuery]int pageIndex = 1,
			[FromQuery]int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			var products = await _services.Products.GetByCriteriaAsync(searchParams, pageIndex, pageSize);
			return Ok(products);
		}

		[HttpGet("get")]
		public async Task<IActionResult> Get(string branchId, string productId)
		{
			var product = await  _services.Products.GetAsync(branchId, productId);
			return Ok(product);
		}
	}
}
