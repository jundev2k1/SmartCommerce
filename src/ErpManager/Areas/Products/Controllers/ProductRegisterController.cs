// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductRegisterController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IValidatorFacade _validatorFacade;
        private readonly ILocalizer _localizer;
        private readonly SessionManager _sessionManager;
        private readonly ValueTextManager _valueText;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductRegisterController(
            IServiceFacade serviceFacade,
            IValidatorFacade validatorFacade,
            ILocalizer localizer,
            SessionManager sessionManager,
            ValueTextManager valueText) : base(serviceFacade, sessionManager)
        {
            _serviceFacade = serviceFacade;
            _validatorFacade = validatorFacade;
            _localizer = localizer;
            _sessionManager = sessionManager;
            _valueText = valueText;
        }

        [HttpGet]
        [PermissionAttribute(Permission.CanCreateProduct)]
        [Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
        public IActionResult Index(string id = "")
        {
            ViewBag.DropdownItems = GetInitDropdownListItems(new ProductModel());
            if (string.IsNullOrEmpty(id) == false)
            {
                var product = _serviceFacade.Products.GetProduct(this.OperatorBranchId, id) ?? new ProductModel();
                product.Images = string.Empty;
                return View(product);
            }

            return View(new ProductModel());
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
            formInput.TrimStringInput();

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

            // Convert temp images to actual images
            var fileUpload = new FileManager(
                files: Array.Empty<IFormFile>(),
                @enum: UploadEnum.ProductImage,
                sessionToken: this.SessionToken,
                fileName: formInput.ProductId);
            fileUpload.ChangeToActualImages();
            formInput.Images = string.Join(",", fileUpload.Result);
            System.IO.File.WriteAllText("C:\\Logs\\log.txt", formInput.Images);

            // Handle create new product
            var isSuccess = _serviceFacade.Products.Insert(formInput);
            if (isSuccess == false) return View(formInput);

            return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
        }

        /// <summary>
        /// Get init dropdown list items
        /// </summary>
        /// <param name="formInput">Form input</param>
        /// <returns>Dropdown list item collection</returns>
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
                        new SelectListItem { Value = formInput.TakeOverId, Text = $"{user.UserId}. {user.FullName}", Selected = true }
                    };
                    ddlCollection.Add(propName, ddlOptions);
                }
            }
            // Add init for product status
            var ddlStatus = _valueText.GetSelectList(
                group => group.Product,
                Constants.VALUETEXT_FIELD_PRODUCT_STATUS,
                formInput.Status.GetStringValue());
            var statusPropertyName = formInput.Properties.GetName(property => property.Status);
            ddlCollection.Add(statusPropertyName, ddlStatus);

            // Add init for display price
            var ddlDisplayPrice = _valueText.GetSelectList(
                group => group.Product,
                Constants.VALUETEXT_FIELD_PRODUCT_DISPLAY_PRICE,
                formInput.DisplayPrice.GetStringValue());
            var displayPricePropertyName = formInput.Properties.GetName(property => property.DisplayPrice);
            ddlCollection.Add(displayPricePropertyName, ddlDisplayPrice);

            return ddlCollection;
        }
    }
}
