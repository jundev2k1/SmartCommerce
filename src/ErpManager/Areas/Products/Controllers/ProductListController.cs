// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.ViewModels;

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
        public IActionResult Index()
        {
            ViewData[Constants.VIEWDATA_KEY_PAGE_INDEX] = 1;
            var condition = new ProductSearchDto { BranchId = this.OperatorBrandId };
            var data = _serviceFacade.Products.Search(condition, 1, Constants.DEFAULT_PAGE_SIZE);

            return View(new ProductListViewModel { PageData = data });
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanReadListProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH)]
        public IActionResult Index(ProductListViewModel viewModel)
        {
            ViewData[Constants.VIEWDATA_KEY_PAGE_INDEX] = viewModel.PageIndex;

            var searchParams = viewModel.SearchFields;
            searchParams.BranchId = this.OperatorBrandId;
            var data = _serviceFacade.Products.Search(searchParams, viewModel.PageIndex, viewModel.PageSize);

            return View(new ProductListViewModel { PageData = data });
        }
    }
}
