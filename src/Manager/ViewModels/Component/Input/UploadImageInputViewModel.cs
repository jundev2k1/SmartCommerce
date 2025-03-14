// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class UploadImageInputViewModel : InputBaseViewModel
	{
		public string[] Images => Value.Split(',');

		public bool IsMultiple { get; set; }

		public string UploadType = string.Empty;

		public string UploadFileName = string.Empty;
	}
}
