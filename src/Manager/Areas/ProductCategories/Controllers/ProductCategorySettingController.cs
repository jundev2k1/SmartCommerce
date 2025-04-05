// Copyright (c) 2025 - Jun Dev. All rights reserved

using SmartCommerce.Manager.Areas.ProductCategories.ViewModels;

namespace SmartCommerce.Manager.Areas.ProductCategories.Controllers
{
	[Area(Constants.MODULE_PRODUCT_CATEGORY_AREA)]
	public sealed class ProductCategorySettingController : ProductCategoryBaseController
    {
		public ProductCategorySettingController(
			IServiceFacade serviceFacade,
			IValidatorFacade validatorFacade,
			ILocalizer localizer,
			SessionManager sessionManager,
			ValueTextManager valueTextManager,
			IFileLogger logger) : base(serviceFacade, sessionManager, localizer, logger, valueTextManager)
		{
		}

		[HttpGet]
		[Authorization(Permission.CanReadProductCategory)]
		[Route(Constants.MODULE_PRODUCT_CATEGORY_SETTING_PATH, Name = Constants.MODULE_PRODUCT_CATEGORY_SETTING_NAME)]
		public IActionResult Index()
		{
			var data = _serviceFacade.ProductCategories.Get(this.OperatorBranchId, "");
			if (data == null) return RedirectToErrorPage(Constants.ERRORMSG_KEY_DATA_NOT_FOUND, ErrorCodeEnum.DataNotFound);

			string temp = $"[\r\n  {{\r\n    parentID: 'root',\r\n    categoryID: '001',\r\n    level: 1,\r\n    name: 'Root 001',\r\n    description: '',\r\n    priority: 1,\r\n    items: [],\r\n    hasChildItem: false,\r\n    isDisplay: false,\r\n  }},\r\n  {{\r\n    parentID: 'root',\r\n    categoryID: '002',\r\n    level: 1,\r\n    name: 'Root 002',\r\n    description: '',\r\n    priority: 2,\r\n    items: [\r\n      {{\r\n        parentID: '002',\r\n        categoryID: '002001',\r\n        level: 2,\r\n        name: 'Cate 2 - 1',\r\n        description: '',\r\n        priority: 1,\r\n        items: [],\r\n        hasChildItem: false,\r\n        isDisplay: false,\r\n      }},\r\n      {{\r\n        parentID: '002',\r\n        categoryID: '002002',\r\n        level: 2,\r\n        name: 'Cate 2 - 2',\r\n        description: '',\r\n        priority: 2,\r\n        items: [\r\n          {{\r\n            parentID: '002002',\r\n            categoryID: '002002001',\r\n            level: 3,\r\n            name: 'Cate 2 - 1',\r\n            description: '',\r\n            priority: 1,\r\n            items: [],\r\n            hasChildItem: false,\r\n            isDisplay: false,\r\n          }},\r\n          {{\r\n            parentID: '002002',\r\n            categoryID: '002002002',\r\n            level: 3,\r\n            name: 'Cate 2 - 1',\r\n            description: '',\r\n            priority: 1,\r\n            items: [],\r\n            hasChildItem: false,\r\n            isDisplay: false,\r\n          }},\r\n        ],\r\n        hasChildItem: true,\r\n        isDisplay: false,\r\n      }},\r\n    ],\r\n    hasChildItem: true,\r\n    isDisplay: false,\r\n  }},\r\n  {{\r\n    parentID: 'root',\r\n    categoryID: '003',\r\n    level: 1,\r\n    name: 'Root 003',\r\n    description: '',\r\n    priority: 3,\r\n    items: [],\r\n    hasChildItem: true,\r\n    isDisplay: false,\r\n  }},\r\n]";
			return View(new ProductCategorySettingViewModel() { PageData = temp });
		}

        [HttpGet]
        [Authorization(Permission.CanReadProductCategory)]
		[Route("/product-category/get-child-category")]
		public JsonResult GetChildCategory(string categoryId)
		{
			return Json($"[\r\n  {{\r\n    \"parentID\": \"003\",\r\n    \"categoryID\": \"003001\",\r\n    \"level\": 1,\r\n    \"name\": \"Cate child 1\",\r\n    \"description\": \"\",\r\n    \"priority\": 1,\r\n    \"hasChildItem\": true,\r\n    \"isDisplay\": false,\r\n    \"items\": []\r\n  }},\r\n  {{\r\n    \"parentID\": \"003\",\r\n    \"categoryID\": \"003002\",\r\n    \"level\": 1,\r\n    \"name\": \"Cate child 2\",\r\n    \"description\": \"\",\r\n    \"priority\": 1,\r\n    \"hasChildItem\": true,\r\n    \"isDisplay\": false,\r\n    \"items\": []\r\n  }},\r\n  {{\r\n    \"parentID\": \"003\",\r\n    \"categoryID\": \"003001\",\r\n    \"level\": 1,\r\n    \"name\": \"Cate child 3\",\r\n    \"description\": \"\",\r\n    \"priority\": 1,\r\n    \"hasChildItem\": true,\r\n    \"isDisplay\": false,\r\n    \"items\": []\r\n  }}\r\n]");
		}

		private void GetRequestParam()
		{

		}
	}
}
