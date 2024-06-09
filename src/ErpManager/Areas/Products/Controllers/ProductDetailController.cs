// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public sealed class ProductDetailController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly SessionManager _sessionManager;
        public ProductDetailController(IServiceFacade serviceFacade, SessionManager sessionManager)
            : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _sessionManager = sessionManager;
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
