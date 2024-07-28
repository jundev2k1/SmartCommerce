// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.Domain.Mapping;
using ErpManager.Manager.Areas.Products.ViewModels;

namespace ErpManager.Manager.Areas.Products.Controllers
{
	public class ProductBaseController : BaseController
	{
		protected readonly ValueTextManager _valueTextManager;

		public ProductBaseController(
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			ILocalizer localizer,
			IFileLogger logger,
			ValueTextManager valueTextManager) : base(serviceFacade, sessionManager, localizer, logger)
		{
			_valueTextManager = valueTextManager;
		}

		/// <summary>
		/// Get init dropdown list items
		/// </summary>
		/// <param name="formInput">Form input</param>
		/// <returns>Dropdown list item collection</returns>
		protected ProductInputOptionViewModel GetInitDropdownListItems(ProductModel formInput)
		{
			var inputOption = new ProductInputOptionViewModel();

			// Add init for take over id
			if (string.IsNullOrEmpty(formInput.TakeOverId) == false)
			{
				var user = _serviceFacade.Users.Get(this.OperatorBranchId, formInput.TakeOverId);
				if (user != null)
				{
					var ddlOptions = new List<SelectListItem>
					{
						new SelectListItem { Text = $"{user.UserId}. {user.FullName}", Value = formInput.TakeOverId, Selected = true }
					};
					inputOption.TakeOverId = ddlOptions;
				}
			}
			// Add init for product status
			var ddlStatus = _valueTextManager.GetSelectList(
				group => group.Product,
				Constants.VALUETEXT_FIELD_PRODUCT_STATUS,
				formInput.Status.GetStringValue());
			inputOption.Status = ddlStatus;

			// Add init for display price
			var ddlDisplayPrice = _valueTextManager.GetSelectList(
				group => group.Product,
				Constants.VALUETEXT_FIELD_PRODUCT_DISPLAY_PRICE,
				formInput.DisplayPrice.GetStringValue());
			inputOption.DisplayPrice = ddlDisplayPrice;

			// Add init for delete flag
			var ddlDeleteFlg = _valueTextManager.GetSelectList(
				group => group.Product,
				Constants.VALUETEXT_FIELD_USER_DELFLG,
				formInput.DelFlg
					? Constants.FLG_PRODUCT_DELFLG_DELETED
					: Constants.FLG_PRODUCT_DELFLG_NONE);
			inputOption.DeleteFlg = ddlDeleteFlg;

			return inputOption;
		}
	}
}
