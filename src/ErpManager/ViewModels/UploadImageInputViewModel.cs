// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.ERP.ViewModels
{
	public sealed class UploadImageInputViewModel
	{
		public string Name { get; set; } = string.Empty;

		public string Value { get; set; } = string.Empty;

		public string[] Images => this.Value.Split(',');

		public string PlaceHolderText { get; set; } = string.Empty;

		public bool IsMultiple { get; set; }

		public string ClassName { get; set; } = string.Empty;

		public string UploadType = string.Empty;

		public string UploadFileName = string.Empty;
	}
}
