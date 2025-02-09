// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Controllers
{
	public sealed class HomeController : BaseController
	{
		private readonly IMailSender _mailSender;
		/// <summary>
		/// Constructor
		/// </summary>
		public HomeController(
			ILocalizer localizer,
			IServiceFacade serviceFacade,
			SessionManager sessionManager,
			IFileLogger logger,
			IMailSender mailSender)
			: base(serviceFacade, sessionManager, localizer, logger)
		{
			_mailSender = mailSender;
		}

		/// <summary>
		/// Dashboard page
		/// </summary>
		[Authorization(Permission.CanAccessDashBoard)]
		[Route("/")]
		[Route(Constants.MODULE_HOME_DASHBOARD_PATH, Name = Constants.MODULE_HOME_DASHBOARD_NAME)]
		public IActionResult Index()
		{
			HandleForLoginSuccess();

			return View();
		}

		/// <summary>
		/// Handle for login success
		/// </summary>
		private void HandleForLoginSuccess()
		{
			var message = _sessionManager.Get(Constants.SESSION_KEY_LOGIN_MESSAGE);
			if (string.IsNullOrEmpty(message)) return;

			_sessionManager.Remove(Constants.SESSION_KEY_LOGIN_MESSAGE);
			ViewBag.LoginMessage = message;
		}
	}
}