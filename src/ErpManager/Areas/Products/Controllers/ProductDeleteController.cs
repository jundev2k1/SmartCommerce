// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductDeleteController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IValidatorFacade _validatorFacade;
        private readonly ILocalizer _localizer;
        private readonly SessionManager _sessionManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductDeleteController(
            IServiceFacade serviceFacade,
            IValidatorFacade validatorFacade,
            ILocalizer localizer,
            SessionManager sessionManager) : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _validatorFacade = validatorFacade;
            _localizer = localizer;
            _sessionManager = sessionManager;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanDeleteProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTDELETE_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTDELETE_NAME)]
        public IActionResult Index(string id)
        {
            var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, id);
            if (product == null) return RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);

            var isSuccess = _serviceFacade.Products.Delete(this.OperatorBranchId, product.ProductId);
            if (!isSuccess) RedirectToRoute(Constants.MODULE_ERROR_ERROR_NAME);

            return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
        }
    }
}
