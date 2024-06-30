// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Products.Controllers;

namespace ErpManager.ERP.Areas.Product.Controllers
{
	[Area(Constants.MODULE_PRODUCT_AREA)]
	public sealed class ProductRegisterController : ProductBaseController
	{
		private readonly IValidatorFacade _validatorFacade;

		/// <summary>
		/// Constructor
		/// </summary>
		public ProductRegisterController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
			_validatorFacade = validatorFacade;
		}

		[HttpGet]
		[PermissionAttribute(Permission.CanCreateProduct)]
		[Route(Constants.MODULE_PRODUCT_PRODUCTREGISTER_PATH, Name = Constants.MODULE_PRODUCT_PRODUCTREGISTER_NAME)]
		public IActionResult Index(string id = "")
		{
			var product = new ProductModel();
			if (string.IsNullOrEmpty(id) == false)
			{
				product = _serviceFacade.Products.Get(this.OperatorBranchId, id) ?? new ProductModel();
				product.Images = string.Empty;
			}

			ViewBag.DropdownItems = GetInitDropdownListItems(product);
			return View(product);
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

			// Handle create new product
			var isSuccess = _serviceFacade.Products.Insert(formInput);
			if (isSuccess == false) return View(formInput);

			return RedirectToRoute(Constants.MODULE_PRODUCT_PRODUCTLIST_NAME);
		}
	}
}
