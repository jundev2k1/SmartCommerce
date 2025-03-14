// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewComponents
{
	public sealed class PasswordInputViewComponent : ViewComponentBase
	{
		/// <summary>
		/// Password input view component
		/// </summary>
		/// <param name="input">Password input model</param>
		/// <returns>Password input component</returns>
		public IViewComponentResult Invoke(PasswordInputViewModel input)
		{
			return View(input);
		}
	}
}
