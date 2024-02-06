// Copyright (c) 2024 - Jun Dev. All rights reserved

using Common.Constants;
using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductListController : Controller
    {
        [HttpGet]
        [PermissionAttribute(Permission.CanReadListProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanReadListProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index(ProductModel model)
        {
            return View();
        }
    }
}
