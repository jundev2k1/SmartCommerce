// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common;

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductRegisterController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IValidatorFacade _validatorFacade;
        private readonly ILocalizer _localizer;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductRegisterController(IServiceFacade serviceFacade, IValidatorFacade validatorFacade, ILocalizer localizer)
        {
            _serviceFacade = serviceFacade;
            _validatorFacade = validatorFacade;
            _localizer = localizer;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanCreateProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanCreateProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index(ProductModel formInput)
        {
            // Set default value for form input
            formInput.BranchId = this.OperatorBranchId;
            formInput.CreatedBy = this.OperatorId;
            formInput.LastChanged = this.OperatorName;

            // Validate form input
            var validateResult = _validatorFacade.ProductValidate(formInput);
            if (validateResult.IsValid == false)
            {
                AddErrorToModelState(validateResult);
                return View();
            }

            // Handle create new product
            var isSuccess = _serviceFacade.Products.Insert(formInput);
            if (isSuccess == false) return View();

            return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
        }
    }
}
