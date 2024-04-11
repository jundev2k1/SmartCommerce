// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common.Util;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErpManager.ERP.Areas.Product.Controllers
{
    [Area(Constants.MODULE_PRODUCT_AREA)]
    public class ProductEditController : BaseController
    {
        private readonly IServiceFacade _serviceFacade;
        private readonly IValidatorFacade _validatorFacade;
        private readonly ILocalizer _localizer;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductEditController(IServiceFacade serviceFacade, IValidatorFacade validatorFacade, ILocalizer localizer)
        {
            _serviceFacade = serviceFacade;
            _validatorFacade = validatorFacade;
            _localizer = localizer;
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

            input.BranchId = this.OperatorBranchId;
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
            var ddlStatus = new List<SelectListItem>
            {
                new SelectListItem { Value = ProductStatusEnum.Sold.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductStatus_Sold"] },
                new SelectListItem { Value = ProductStatusEnum.Normal.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductStatus_Normal"] },
                new SelectListItem { Value = ProductStatusEnum.UrgentSale.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductStatus_UrgentSale"] },
                new SelectListItem { Value = ProductStatusEnum.GoodPrice.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductStatus_GoodPrice"] },
            };
            var selectedStatus = ddlStatus.FirstOrDefault(status => status.Value.Equals(formInput.Status));
            if (selectedStatus != null) selectedStatus.Selected = true;
            var statusPropertyName = formInput.Properties.GetName(property => property.Status);
            ddlCollection.Add(statusPropertyName, ddlStatus);

            // Add init for display price
            var ddlDisplayPrice = new List<SelectListItem>
            {
                new SelectListItem { Value = DisplayPriceEnum.Price1.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductDisplayPrice1"] },
                new SelectListItem { Value = DisplayPriceEnum.Price2.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductDisplayPrice2"] },
                new SelectListItem { Value = DisplayPriceEnum.Price3.GetStringValue<int>(), Text = _localizer.ValueTexts["ValTxt_ProductDisplayPrice3"] },
            };
            var selectedDisplayPrice = ddlDisplayPrice.FirstOrDefault(status => status.Value.Equals(formInput.DisplayPrice));
            if (selectedDisplayPrice != null) selectedDisplayPrice.Selected = true;
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
