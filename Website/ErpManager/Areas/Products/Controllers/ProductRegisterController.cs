using Common.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductRegisterController : Controller
    {
        [HttpGet]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index(ProductModel model)
        {
            return View();
        }
    }
}
