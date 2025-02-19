// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	/// <summary>
	/// Pagination view model (View Component)
	/// </summary>
	public sealed class PaginationComponentViewModel
	{
		/// <summary>Request parameters</summary>
		public Dictionary<string, string> RequestParameters { get; set; } = new Dictionary<string, string>();

		/// <summary>Current page index, returns <c>1</c> if the request not exists page number</summary>
		public int PageIndex { get; set; }

		/// <summary>Display page size</summary>
		public int PageSize { get; set; }

		/// <summary>Total number of items with paging</summary>
		public int SearchCount { get; set; }

		/// <summary>Total number of items available</summary>
		public int SearchHitCount { get; set; }

		/// <summary>Total number of possible pages</summary>
		public int TotalPage => MathUtilitiy.DivRoundUp(this.SearchHitCount, this.PageSize);

		/// <summary>Page items information</summary>
		public string PaginationItemInfo
			=> $"{(this.PageSize * (this.PageIndex - 1)) + this.SearchCount}/{this.SearchHitCount}";

		/// <summary>Method to create redirect page</summary>
		public Func<int, string>? CreatePaginationUrl = null;
	}
}
