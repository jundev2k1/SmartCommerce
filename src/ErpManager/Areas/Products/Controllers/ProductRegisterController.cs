// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductRegisterController : Controller
    {
        [HttpGet]
        [PermissionAttribute(Permission.CanCreateProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanCreateProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index(ProductModel model)
        {
            return View();
        }
    }
}
