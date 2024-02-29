// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.ViewModels;

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductListController : BaseController
    {
        private IServiceFacade _serviceFacade;
        public ProductListController(IServiceFacade serviceFacade)
        {
            _serviceFacade = serviceFacade;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanReadListProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTLIST_NAME)]
        public IActionResult Index(int page = 1)
        {
            var condition = new ProductSearchDto { BranchId = this.OperatorBranchId };
            var data = _serviceFacade.Products.Search(condition, page, Constants.DEFAULT_PAGE_SIZE);

            return View(new ProductListViewModel { PageData = data });
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanReadListProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTLIST_PATH)]
        public IActionResult Index(ProductListViewModel viewModel)
        {
            var searchParams = viewModel.SearchFields;
            searchParams.BranchId = this.OperatorBranchId;
            viewModel.PageData = _serviceFacade.Products.Search(searchParams, viewModel.PageIndex, viewModel.PageSize);

            // Check page index out of range data collection
            if (viewModel.PageData.TotalPage < viewModel.PageIndex)
            {
                viewModel.PageData = _serviceFacade.Products.Search(searchParams, 1, viewModel.PageSize);
                viewModel.PageIndex = 1;
            }

            return View(viewModel);
        }
    }
}
