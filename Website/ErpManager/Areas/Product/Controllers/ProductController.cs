using Common.Constants;
using Microsoft.AspNetCore.Mvc;

namespace ErpManager.Web.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductController : Controller
    {
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
