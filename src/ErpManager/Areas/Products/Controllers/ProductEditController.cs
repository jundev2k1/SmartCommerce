// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public sealed class ProductEditController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IValidatorFacade _validatorFacade;
        private readonly ILocalizer _localizer;
        private readonly SessionManager _sessionManager;
        private readonly ValueTextManager _valueTextManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductEditController(
            IServiceFacade serviceFacade,
            IValidatorFacade validatorFacade,
            ILocalizer localizer,
            SessionManager sessionManager,
            ValueTextManager valueTextManager) : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _validatorFacade = validatorFacade;
            _localizer = localizer;
            _sessionManager = sessionManager;
            _valueTextManager = valueTextManager;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanEditProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTEDIT_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTEDIT_NAME)]
        public IActionResult Index(string id)
        {
            var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, id);
            if (product == null) return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);

            ViewBag.DropdownItems = GetInitDropdownListItems(new ProductModel());
            return View(product);
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanEditProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTEDIT_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTEDIT_NAME)]
        public IActionResult Index([FromRoute] string id, ProductModel formInput)
        {
            // Set default value for form input
            formInput.ProductId = id;
            formInput.TrimStringInput();
            SetDataForUpdate(ref formInput);

            // Set initial value for dropdown list
            ViewBag.DropdownItems = GetInitDropdownListItems(formInput);

            // Validate form input
            ModelState.Clear();
            var validateResult = _validatorFacade.ProductValidate(formInput);
            if (validateResult.IsValid == false)
            {
                AddErrorToModelState(validateResult);
                return View(formInput);
            }

            // Handle create new product
            var isSuccess = _serviceFacade.Products.Update(formInput);
            if (isSuccess == false) return View(formInput);

            return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTDETAIL_NAME, new { id = formInput.ProductId });
        }

        /// <summary>
        /// Set data for update
        /// </summary>
        /// <param name="input">Input</param>
        private void SetDataForUpdate(ref ProductModel input)
        {
            var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, input.ProductId);
            if (product == null) return;

            var productImages = _serviceFacade.Products.UpdateNewestProductImages(product.BranchId, product.ProductId);
            if (productImages == null) throw new Exception("Product id is not exist to update newest image");

            input.BranchId = this.OperatorBranchId;
            input.Images = productImages;
            input.Description = product.Description;
            input.LastChanged = this.OperatorName;
            input.DateChanged = DateTime.Now;
            input.DateCreated = product?.DateCreated;
            input.CreatedBy = product?.CreatedBy ?? string.Empty;
        }

        /// <summary>
        /// Get init dropdown list items
        /// </summary>
        /// <param name="formInput">Form input</param>
        /// <returns>dropdown list item collection</returns>
        private Dictionary<string, List<SelectListItem>> GetInitDropdownListItems(ProductModel formInput)
        {
            var ddlCollection = new Dictionary<string, List<SelectListItem>>();

            // Add init for take over id
            if (string.IsNullOrEmpty(formInput.TakeOverId) == false)
            {
                var user = _serviceFacade.Users.GetUser(this.OperatorBranchId, formInput.TakeOverId);
                if (user != null)
                {
                    var propName = formInput.Properties.GetName(prop => prop.TakeOverId);
                    var ddlOptions = new List<SelectListItem>
                    {
                        new SelectListItem { Value = formInput.TakeOverId, Text = $"{user.UserId}. {user.FirstName} {user.LastName}", Selected = true }
                    };
                    ddlCollection.Add(propName, ddlOptions);
                }
            }

            // Add init for product status
            var ddlStatus = _valueTextManager.GetSelectList(
                group => group.Product,
                Constants.VALUETEXT_FIELD_PRODUCT_STATUS,
                formInput.Status.GetStringValue());
            var statusPropertyName = formInput.Properties.GetName(property => property.Status);
            ddlCollection.Add(statusPropertyName, ddlStatus);

            // Add init for display price
            var ddlDisplayPrice = _valueTextManager.GetSelectList(
                group => group.Product,
                Constants.VALUETEXT_FIELD_PRODUCT_DISPLAY_PRICE,
                formInput.DisplayPrice.GetStringValue());
            var displayPricePropertyName = formInput.Properties.GetName(property => property.DisplayPrice);
            ddlCollection.Add(displayPricePropertyName, ddlDisplayPrice);

            return ddlCollection;
        }

        [HttpPost]
        [PermissionAttribute(Permission.CanEditProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTEDIT_DESCRIPTION_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTEDIT_DESCRIPTION_NAME)]
        public bool UpdateDescription([FromRoute] string id, [FromBody] string description)
        {
            var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, id);
            if (product == null) return false;

            product.Description = description;
            return _serviceFacade.Products.UpdateDescription(product);
        }
    }
}
