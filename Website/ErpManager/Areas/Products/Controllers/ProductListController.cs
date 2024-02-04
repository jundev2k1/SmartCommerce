using Common.Constants;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductListController : Controller
    {
        [HttpGet]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index(ProductModel model)
        {
            return View();
        }
    }
}
