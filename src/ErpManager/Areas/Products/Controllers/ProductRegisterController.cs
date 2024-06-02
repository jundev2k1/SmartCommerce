// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Common.Util;
using ErpManager.Infrastructure.Common.Enum;
using ErpManager.Infrastructure.Upload;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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
            ViewBag.DropdownItems = GetInitDropdownListItems(new ProductModel());
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
            Debugger.Break();
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
    }
}
