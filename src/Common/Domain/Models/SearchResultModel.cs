// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Domain.Models
{
	public class SearchResultModel<TModel>
	{
		public TModel[] Items { get; set; } = Array.Empty<TModel>();

		public int TotalRecord { get; set; }

		public int TotalPage { get; set; }
	}
}
