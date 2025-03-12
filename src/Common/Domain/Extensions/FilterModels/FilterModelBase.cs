// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Domain.Extensions.FilterModels
{
	public class FilterModelBase<TModel> : ModelBase
	{
		public string OrderBy { get; set; } = string.Empty;

		public string OrderByDirection { get; set; } = string.Empty;

		public DateTime? DateCreatedFrom { get; set; }

		public DateTime? DateCreatedTo { get; set; }

		public DateTime? DateChangedFrom { get; set; }

		public DateTime? DateChangedTo { get; set; }

		public string CreatedBy { get; set; } = string.Empty;

		public bool DelFlg { get; set; }

		public int PageNumber { get; set; } = 1;

		public int PageSize { get; set; } = 20;

		public int PageSkip => (this.PageNumber - 1) * this.PageSize;
	}
}
