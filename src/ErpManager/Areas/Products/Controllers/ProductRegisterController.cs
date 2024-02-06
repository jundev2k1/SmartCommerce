using Common.Constants;
using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Product.Controllers
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
