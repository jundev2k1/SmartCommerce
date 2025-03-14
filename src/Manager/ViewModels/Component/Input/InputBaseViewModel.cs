﻿// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public class InputBaseViewModel
	{
		public string Name { get; set; } = string.Empty;

		public string Value { get; set; } = string.Empty;

		public string PlaceHolderText { get; set; } = string.Empty;

		public InputTypeEnum Type { get; set; } = InputTypeEnum.Text;

		public string ClassName { get; set; } = string.Empty;
	}
}
