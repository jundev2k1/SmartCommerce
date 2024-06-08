// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Products.ViewModels
{
    public class ProductListViewModel
    {
        public SearchResultModel<ProductModel> PageData { get; set; } = new SearchResultModel<ProductModel>();

        public ProductSearchDto SearchFields { get; set; } = new ProductSearchDto();

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = Constants.DEFAULT_PAGE_SIZE;
    }
}
