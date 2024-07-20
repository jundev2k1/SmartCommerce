// Copyright (c) 2024 - Jun Dev. All rights reserved

using ErpManager.ERP.Areas.Users.ViewModels;

namespace ErpManager.ERP.Areas.Users.Controllers
{
	public class UserBaseController : BaseController
	{
		protected readonly ValueTextManager _valueTextManager;

		public UserBaseController(
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
		protected UserInputOptionViewModel GetInitDropdownListItems(UserModel formInput)
		{
			var userInputOption = new UserInputOptionViewModel();

			// Add init for status
			var ddlStatus = _valueTextManager.GetSelectList(
				group => group.User,
				Constants.VALUETEXT_FIELD_USER_STATUS,
				formInput.Status.GetStringValue());
			userInputOption.Status = ddlStatus;

			// Add init for sex
			var ddlSex = _valueTextManager.GetSelectList(
				group => group.User,
				Constants.VALUETEXT_FIELD_USER_SEX,
				formInput.Sex.GetStringValue());
			userInputOption.Sex = ddlSex;

			// Add init for delete flag
			var ddlDeleteFlg = _valueTextManager.GetSelectList(
				group => group.User,
				Constants.VALUETEXT_FIELD_USER_DELFLG,
				formInput.DelFlg
					? Constants.FLG_USER_DELFLG_DELETED
					: Constants.FLG_USER_DELFLG_NONE);
			userInputOption.DeleteFlg = ddlDeleteFlg;

			return userInputOption;
		}
	}
}
