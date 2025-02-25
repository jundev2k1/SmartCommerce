// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class FormContactViewModel
	{
		public string TargetButtonId { get; set; } = string.Empty;

		public FormContactTypeEnum TypeForm { get; set; }

		public bool IsShowType { get; set; }
	}

	public class FormContactRequestViewModel
	{
		public FormContactTypeEnum Type { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Tel { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Message { get; set; } = string.Empty;
	}
}
