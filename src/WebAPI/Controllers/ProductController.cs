// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Persistence.Common;

namespace ErpManager.WebAPI.Controllers
{
	[ApiController]
	public sealed class ProductController(IServiceFacade services) : BaseController
	{
		private readonly IServiceFacade _services = services;

		[HttpGet("Search")]
		public async Task<IActionResult> Search()
		{
			var products = await Task.Run(() => _services.Products.GetAll("0"));
			return Ok(products);
		}
	}
}
