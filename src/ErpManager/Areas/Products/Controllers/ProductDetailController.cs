// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Dtos.SearchDtos;

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductDetailController : BaseController
    {
        private IServiceFacade _serviceFacade;
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;
        public ProductDetailController(IServiceFacade serviceFacade, IStringLocalizer<GlobalLocalizer> localizer)
        {
            _serviceFacade = serviceFacade;
            _localizer = localizer;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadDetailProduct)]
        [Route($"{Constants.MODULE_PRODUCT_PRODUCTDETAIL_PATH}/{{id}}", Name = Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME)]
        public IActionResult Index(string id)
        {
            var data = _serviceFacade.Products.GetProduct(this.OperatorBrandId, id);

            return View(data);
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanReadDetailProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
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
