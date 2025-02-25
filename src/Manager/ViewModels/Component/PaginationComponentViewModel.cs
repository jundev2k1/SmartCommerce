// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace SmartCommerce.Manager.ViewModels
{
	/// <summary>
	/// Pagination view model (View Component)
	/// </summary>
	public sealed class PaginationComponentViewModel
	{
		/// <summary>
		/// Get limit pagination number
		/// </summary>
		/// <param name="isEnd">Is end limit number?</param>
		/// <returns>Limit number</returns>
		private int GetLimitPaginationNumber(bool isEnd = false)
		{
			// Returns valid limit number if the page number is out of limit
			if (IsOutOfLimit) return isEnd ? TotalPage : 1;

			if (isEnd)
			{
				var endPageNo = PageIndex + 3;
				return endPageNo <= TotalPage ? endPageNo : TotalPage;
			}
			else
			{
				var startPageNo = PageIndex - 3;
				return startPageNo > 0 ? startPageNo : 1;
			}
		}

		/// <returns>True if the current page count exceeds the total searchable page count limit</returns>
		public bool IsOutOfLimit => (this.SearchCount == 0) && (this.PageIndex > this.TotalPage);

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
		public int TotalPage { get; set; }

		/// <summary>Page items information</summary>
		public string PaginationItemInfo
			=> $"{PageSize * (PageIndex - 1) + SearchCount}/{SearchHitCount}";

		/// <summary>Start page</summary>
		public int StartPage => GetLimitPaginationNumber();

		/// <summary>End page</summary>
		public int EndPage => GetLimitPaginationNumber(true);

		/// <summary>Method to create redirect page</summary>
		public Func<int, string>? CreatePaginationUrl = null;
	}
}
