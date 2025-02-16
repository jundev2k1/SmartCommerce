// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public abstract class ViewComponentBase : ViewComponent
	{
		protected readonly ILocalizer _localizer;
		protected readonly IServiceFacade _serviceFacade;
		protected readonly ValueTextManager _valueTextManager;
		protected readonly SessionManager _sessionManager;

		protected ViewComponentBase(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			ValueTextManager valueTextManager,
			SessionManager sessionManager)
		{
			_localizer = localizer;
			_serviceFacade = serviceFacade;
			_valueTextManager = valueTextManager;
			_sessionManager = sessionManager;
		}

		/// <summary>Current operator branch ID</summary>
		protected string OperatorBranchID => _sessionManager.OperatorBranchId;
		/// <summary>Current operator ID</summary>
		protected string OperatorID => _sessionManager.OperatorId;
		/// <summary>Current operator name</summary>
		protected string OperatorName => _sessionManager.OperatorName;
		/// <summary>Current operator permission list</summary>
		protected string[] OperatorPermissions => _sessionManager.OperatorPermissionList;
	}
}
