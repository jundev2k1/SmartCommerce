// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Common;
using ErpManager.Domain.Extensions.FilterModels;
using ErpManager.Persistence.Common;

namespace ErpManager.WebAPI.Controllers
{
	[ApiController]
	public sealed class CategoryController(IServiceFacade services) : BaseController
	{
		private readonly IServiceFacade _services = services;

		[HttpPost("getByCriteria")]
		public async Task<IActionResult> GetByCriteria(
			[FromBody] CategoryFilterModel searchParams,
			[FromQuery]int pageIndex = 1,
			[FromQuery]int pageSize = Constants.DEFAULT_PAGE_SIZE)
		{
			var products = await _services.Categories.GetByCriteriaAsync(searchParams, pageIndex, pageSize);
			return Ok(products);
		}

		[HttpGet("getAllRootCategories")]
		public async Task<IActionResult> GetAllRootCategories(string branchId)
		{
			var categories = await _services.Categories.GetAllRootCategoriesAsync(branchId);
			return Ok(categories);
		}

		[HttpGet("get")]
		public async Task<IActionResult> Get(string branchId, string productId)
		{
			var product = await  _services.Categories.GetAsync(branchId, productId);
			return Ok(product);
		}
	}
}
