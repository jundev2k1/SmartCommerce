// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductDetailController : BaseController
    {
        private IServiceFacade _serviceFacade;
        public ProductDetailController(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadDetailProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTDETAIL_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME)]
        public IActionResult Index([FromRoute]string id)
        {
            var data = _serviceFacade.Products.GetProduct(this.OperatorBranchId, id);
            if (data == null) return RedirectToErrorPage(Constants.ERRORMSG_KEY_DATA_NOT_FOUND, ErrorCodeEnum.DataNotFound);

            return View(data);
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanReadDetailProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTDETAIL_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME)]
        public IActionResult Index(ProductModel model)
        {
            return View();
        }

        private int GetPageIndex()
        {
            var isSuccess = int.TryParse(Request.Query[Constants.PARAM_KEY_PAGE_INDEX].ToStringOrEmpty(), out var page);
            return isSuccess ? page : 1;
        }
    }
}
