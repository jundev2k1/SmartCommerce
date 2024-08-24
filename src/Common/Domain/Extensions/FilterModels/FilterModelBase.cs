// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Extensions.FilterModels
{
	public class FilterModelBase<TModel> : ModelBase<TModel>
	{
		public DateTime? DateCreatedFrom { get; set; }

		public DateTime? DateCreatedTo { get; set; }

		public DateTime? DateChangedFrom { get; set; }

		public DateTime? DateChangedTo { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public bool DelFlg { get; set; }
	}
}
