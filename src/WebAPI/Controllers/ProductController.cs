// Copyright (c) 2024 - Jun Dev. All rights reserved

using Microsoft.AspNetCore.Mvc;

namespace ErpManager.WebAPI.Controllers
{
	[ApiController]
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
