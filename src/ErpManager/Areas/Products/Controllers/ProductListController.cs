// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Dtos.SearchDtos;
using ErpManager.ERP.Message;

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductListController : BaseController
    {
        private IServiceFacade _serviceFacade;
        private readonly IStringLocalizer<GlobalLocalizer> _localizer;
        public ProductListController(IServiceFacade serviceFacade, IStringLocalizer<GlobalLocalizer> localizer)
        {
            _serviceFacade = serviceFacade;
            _localizer = localizer;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadListProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index(int page = 1)
        {
            ViewData[Constants.VIEWDATA_KEY_PAGE_INDEX] = page;

            var condition = new ProductSearchDto
            {
                BranchId = this.OperatorBrandId,
            };
            var data = _serviceFacade.Products.Search(condition, page, Constants.DEFAULT_PAGE_SIZE);

            return View(data);
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanReadListProduct)]
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
