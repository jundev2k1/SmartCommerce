// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class FormContactViewComponent : ViewComponentBase
	{
		public FormContactViewComponent(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
			: base(localizer, serviceFacade, valueTextManager, sessionManager)
		{
		}

		public IViewComponentResult Invoke(FormContactViewModel model)
		{
			var typeForm = model.TypeForm switch
			{
				FormContactTypeEnum.Report => Constants.FLG_COMMON_FORMCONTACT_REPORT,
				FormContactTypeEnum.ContactAdmin => Constants.FLG_COMMON_FORMCONTACT_CONTACTADMIN,
				_ => throw new NotExistInEnumException()
			};
			var ddlFormTypeData = _valueTextManager.GetSelectList(
				group => group.Common,
				Constants.VALUETEXT_FIELD_COMMON_FORM_CONTACT,
				defaultValue: typeForm);
			ViewBag.FormType = ddlFormTypeData;
			return View(model);
		}
	}
}
