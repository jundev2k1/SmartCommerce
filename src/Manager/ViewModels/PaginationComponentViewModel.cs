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
		public int PageIndex
		{
			get
			{
				var pageNo = this.RequestParameters.GetValueOrDefault(Constants.REQUEST_KEY_PAGE_NO);
				return !string.IsNullOrEmpty(pageNo) ? int.Parse(pageNo) : 1;
			}
		}

		/// <summary>Display page size</summary>
		public int PageSize
		{
			get
			{
				var pageSize = this.RequestParameters.GetValueOrDefault(Constants.REQUEST_KEY_PAGE_SIZE);
				return !string.IsNullOrEmpty(pageSize) ? int.Parse(pageSize) : Constants.DEFAULT_PAGE_SIZE;
			}
		}

		/// <summary>Total number of items with paging</summary>
		public int ItemCount { get; set; }

		/// <summary>Total number of items available</summary>
		public int TotalHitCount { get; set; }

		/// <summary>Total number of possible pages</summary>
		public int TotalPage => MathUtilitiy.DivRoundUp(this.TotalHitCount, this.PageSize);

		/// <summary>Page items information</summary>
		public string PaginationItemInfo
			=> $"{(this.PageSize * (this.PageIndex - 1)) + this.ItemCount}/{this.TotalHitCount}";

		/// <summary>Method to create redirect page</summary>
		public Func<int, string>? CreatePaginationUrl = null;
	}
}
