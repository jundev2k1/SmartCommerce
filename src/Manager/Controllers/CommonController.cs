// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.Controllers
{
	public sealed class CommonController : BaseController
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		public CommonController(
			IServiceFacade serviceFacade,
			IWebHostEnvironment webHostEnvironment,
			SessionManager sessionManager,
			ILocalizer localizer,
			IFileLogger logger)
			: base(serviceFacade, sessionManager, localizer, logger)
		{
			_webHostEnvironment = webHostEnvironment;
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_CHANGE_LANGUAGE_PATH, Name = Constants.ENDPOINT_COMMON_CHANGE_LANGUAGE_NAME)]
		public IActionResult LanguageSwitcher(string culture, string returnUrl)
		{
			// Set cookie option
			var cookieOption = new CookieOptions
			{
				Expires = DateTimeOffset.UtcNow.AddYears(1)
			};

			// Set cookie with chosen language
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				cookieOption);

			return Redirect(returnUrl);
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_GET_PROVINCE_LIST)]
		public IActionResult GetProvinces(string searchKey = "")
		{
			var provinces = AddressManager.Instance.Provinces;

			if (string.IsNullOrEmpty(searchKey.Trim()) == false)
			{
				provinces = provinces
					.Where(model =>
						model.ProvinceId.ToLower().StartsWith(searchKey)
						|| model.EnglishName.ToLower().Contains(searchKey)
						|| model.VietnameseName.ToLower().Contains(searchKey)
						|| model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey)
						|| model.PlateCode.Contains(searchKey))
					.Take(6)
					.ToList();
			}

			return Json(provinces);
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_GET_DISTRICT_LIST)]
		public IActionResult GetDistricts(string searchKey = "", string provinceId = "")
		{
			// Get list by province id
			var districtGroups = AddressManager.Instance.Districts;
			var modelList = (string.IsNullOrEmpty(provinceId) == false)
				? districtGroups.FirstOrDefault(group => group.ProvinceId == provinceId)?.Items
				: districtGroups.SelectMany(group => group.Items);
			if (modelList == null) return Json(Array.Empty<AddressDistrictJsonModel>());

			// Check search key 
			if ((string.IsNullOrEmpty(searchKey.Trim()))) return Json(modelList);

			// Search by search key
			modelList = modelList
				.Where(model =>
					model.DistrictId.ToLower().StartsWith(searchKey)
					|| model.EnglishName.ToLower().Contains(searchKey)
					|| model.VietnameseName.ToLower().Contains(searchKey)
					|| model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey))
				.Take(6)
				.ToArray();

			return Json(modelList);
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_GET_COMMUNE_LIST)]
		public IActionResult GetCommunes(string searchKey = "", string districtId = "")
		{
			// Get list by district id
			var modelGroupList = AddressManager.Instance.Communes;
			var modelList = (string.IsNullOrEmpty(districtId) == false)
				? modelGroupList.SelectMany(groups => groups.Items).FirstOrDefault(group => group.DistrictId == districtId)?.Items
				: modelGroupList.SelectMany(groups => groups.Items).SelectMany(group => group.Items);
			if (modelList == null) return Json(Array.Empty<AddressCommuneJsonModel>());

			// Check search key 
			if ((string.IsNullOrEmpty(searchKey.Trim())) || (modelList == null)) return Json(modelList);

			// Search by search key
			modelList = modelList
				.Where(model =>
					model.CommuneId.ToLower().StartsWith(searchKey)
					|| model.EnglishName.ToLower().Contains(searchKey)
					|| model.VietnameseName.ToLower().Contains(searchKey)
					|| model.VietnameseName.ToLower().RemoveTextSign().Contains(searchKey))
				.Take(6)
				.ToArray();

			return Json(modelList);
		}

		[HttpPost]
		[Authorization(Permission.CanUploadImageProduct)]
		[Route(Constants.ENDPOINT_COMMON_UPLOAD_IMAGES)]
		public async Task<string> UploadImages(
			[FromForm] IFormFile[] files,
			string type,
			string uploadFileName = "",
			bool isClearTempImages = false)
		{
			var typeUpload = GetTypeUploadByString(type);
			if (typeUpload == UploadEnum.None) throw new NotExistInEnumException();

			var fileManager = new FileManager(files, typeUpload, uploadFileName, this.SessionToken);
			if (isClearTempImages)
			{
				fileManager.DeleteTempImages();
			}
			fileManager.ExecuteUploadImages();
			switch (typeUpload)
			{
				case UploadEnum.ProductImage:
					var product = await _serviceFacade.Products.Get(this.OperatorBranchId, uploadFileName);
					if (product == null) break;

					var productImage = await _serviceFacade.Products.UpdateNewestProductImages(this.OperatorBranchId, uploadFileName);
					if (productImage != null) return productImage;
					break;
			}

			return string.Join(",", fileManager.Result);
		}

		[HttpGet]
		[Authorization(Permission.CanDeleteImageProduct)]
		[Route(Constants.ENDPOINT_COMMON_DELETE_IMAGE)]
		public IActionResult DeleteImage(string filePath)
		{
			try
			{
				var targetPath = string.Format("{0}{1}", _webHostEnvironment.WebRootPath, filePath);
				if (System.IO.File.Exists(targetPath))
				{
					System.IO.File.Delete(targetPath);
					return Json(true);
				}
				throw new Exception();
			}
			catch
			{
				return Json(false);
			}
		}

		[HttpGet]
		[Authorization(Permission.CanReadDetailProduct)]
		[Route(Constants.ENDPOINT_COMMON_GET_SRC_IMAGES)]
		public IActionResult GetExistAndDeleteNotUseTemporaryImages(string type, string filePath = "")
		{
			var result = new List<string>();
			var paths = filePath.Split(",");
			foreach (var path in paths)
			{
				var targetPath = string.Format("{0}{1}", _webHostEnvironment.WebRootPath, path);
				if (System.IO.File.Exists(targetPath))
					result.Add(path);
			}
			var typeUpload = GetTypeUploadByString(type);
			if (typeUpload == UploadEnum.None)
				throw new Exception("type none");

			var fileManager = new FileManager(
				files: Array.Empty<IFormFile>(),
				@enum: typeUpload,
				fileName: string.Empty,
				this.SessionToken);
			fileManager.DeleteNotUseImages(
				expectImages: result.ToArray(),
				isTempDir: true);

			return Json(string.Join(",", result));
		}

		[HttpPost]
		[Authorization(Permission.CanUploadImageProduct)]
		[Route(Constants.ENDPOINT_COMMON_UPDATE_NEWEST_IMAGES)]
		public async Task<IActionResult> UpdateNewestImage(string type, string primaryKey)
		{
			var typeUpload = GetTypeUploadByString(type);
			if (typeUpload == UploadEnum.None)
				throw new Exception("type none");

			switch (typeUpload)
			{
				case UploadEnum.ProductImage:
					var result = await Task.Run(() => _serviceFacade.Products
						.UpdateNewestProductImages(this.OperatorBranchId, primaryKey));
					return Content(result ?? string.Empty);

				default:
					return Content(string.Empty);
			}
		}

		[HttpGet]
		[AllowAnonymous]
		[Route(Constants.ENDPOINT_COMMON_GENERATE_QR_CODE)]
		public async Task<IActionResult> GenerateQRCode(string url)
		{
			if (string.IsNullOrEmpty(url)) return Content(string.Empty);
			try
			{
				// Generate token by inserting new token
				var token = await _serviceFacade.Tokens.GenerateToken(
					branchId: this.OperatorBranchId,
					claims: new Dictionary<string, string>(),
					type: TokenTypeEnum.ProductPreviewToken,
					expirationDateCount: 7,
					createdBy: this.OperatorId);
				if (string.IsNullOrEmpty(token)) return NoContent();

				// Create url
				var uriBuilder = new UriBuilder(url);
				var query = HttpUtility.ParseQueryString(uriBuilder.Query);
				query["token"] = token;
				uriBuilder.Query = query.ToString();
				var urlResult = uriBuilder.ToString();

				// Create QR code
				var qrCode = QRCodeUtility.GetSrcImageQRCode(urlResult);
				return Content(qrCode);
			}
			catch (Exception)
			{
				return Content(string.Empty);
			}
		}
	}
}
