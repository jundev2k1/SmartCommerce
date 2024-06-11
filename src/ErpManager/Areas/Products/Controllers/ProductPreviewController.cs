// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.Controllers;
using ErpManager.ERP.Areas.Products.ViewModels;

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public sealed class ProductPreviewController : ProductBaseController
    {
        public ProductPreviewController(
            IServiceFacade serviceFacade,
            SessionManager sessionManager,
            ILocalizer localizer,
            IFileLogger logger,
            ValueTextManager valueTextManager) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
        {
        }

        [HttpGet]
        [PermissionAttribute(Permission.NonePermission)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTPREVIEW_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTPREVIEW_NAME)]
        public IActionResult Index([FromRoute]string id)
        {
            var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, id);
            if (product == null) return RedirectToErrorPage(Constants.ERRORMSG_KEY_DATA_NOT_FOUND, ErrorCodeEnum.DataNotFound);

            var data = GetProductViewData(product);
            return View(data);
        }

        /// <summary>
        /// Get view data for display
        /// </summary>
        /// <param name="product">Product model</param>
        /// <returns>View model</returns>
        private ProductPreviewViewModel GetProductViewData(ProductModel product)
        {
            var user = _serviceFacade.Users.GetUser(this.OperatorBranchId, product.TakeOverId);
            var relatedProduct = _serviceFacade.Products
                .GetRelatedProducts(this.OperatorBranchId, product.ProductId, 4);
            var currentPath = Path.Combine(
                this.Request.Host.Value,
                this.Request.Path);
            var data = new ProductPreviewViewModel
            {
                Product = product,
                AgentDetail = user,
                RelatedProducts = relatedProduct,
                QRCode = QRCodeUtility.GetSrcImageQRCode(currentPath),
                CanShareQRCode = HasPermission(Permission.CanSharePreviewProduct)
            };

            return data;
        }
    }
}
