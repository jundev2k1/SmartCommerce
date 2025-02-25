// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class LoginPageViewModel
	{
		public string LoginID { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public string OtpCode { get; set; } = string.Empty;

		public bool RememberMe { get; set; } = false;
	}
}
