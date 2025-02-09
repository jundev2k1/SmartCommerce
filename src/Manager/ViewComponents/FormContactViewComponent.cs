// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class FormContactViewComponent : ViewComponent
	{
		private readonly ValueTextManager _valueTextManager;

		public FormContactViewComponent(ValueTextManager valueTextManager)
		{
			_valueTextManager = valueTextManager;
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
