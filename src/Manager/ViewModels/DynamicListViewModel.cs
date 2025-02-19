// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Reflection;

namespace SmartCommerce.Manager.ViewModels
{
	public sealed class DynamicListViewModel
	{
		/// <summary>
		/// Get row attribute
		/// </summary>
		/// <param name="rowData">Row data</param>
		/// <returns>String as row attribute</returns>
		public string GetRowAttribute(object rowData)
		{
			var srtAttribute = this.RowAttributes
				.Select(kvp => $"{kvp.Key}=\"{kvp.Value(rowData)}\"")
				.JoinToString(" ");
			return srtAttribute;
		}

		public IEnumerable<object> DataSource { get; set; } = Array.Empty<object>();

		public CellInfo[] Columns { get; set; } = Array.Empty<CellInfo>();

		public CellInfo[] Cells { get; set; } = Array.Empty<CellInfo>();

		public Dictionary<string, Func<object?, string>> RowAttributes { get; set; } = new();

		/// <summary>Returns false if there is no item in <see cref="DataSource"/></summary>
		public bool HasData => DataSource.Any();

		/// <summary>If there is no item in <see cref="DataSource"/>, it will be displayed as a warning message.</summary>
		public string PlaceholderText { get; set; } = string.Empty;

		/// <summary>Paging information</summary>
		public PageInfo? PageInfo { get; set; }
	}

	/// <summary>
	/// An object that includes cell information to render HTML for a cell
	/// </summary>
	public sealed class CellInfo
	{
		public CellInfo SetCell(
			Func<object> renderView,
			dynamic? attribute = null,
			bool isShowFilter = true)
		{
			this.RenderCellView = (object? rowData) =>
				Task.FromResult<IHtmlContent>(
					new HtmlString(renderView().ToStringOrEmpty()));
			this.AttributeInfo = attribute;
			this.IsShowFilter = isShowFilter;

			return this;
		}
		public CellInfo SetCell<T>(
			Func<T?, object> renderView,
			dynamic? attribute = null,
			bool isShowFilter = true)
		{
			this.RenderCellView = (object? rowData) =>
				Task.FromResult<IHtmlContent>(
					new HtmlString(renderView((T?)rowData).ToStringOrEmpty()));
			this.AttributeInfo = attribute;
			this.IsShowFilter = isShowFilter;

			return this;
		}
		public CellInfo SetCell<T>(
			Func<T?, Task<string>> renderView,
			dynamic? attribute = null,
			bool isShowFilter = true)
		{
			this.RenderCellView = async (object? rowData) =>
				new HtmlString(await renderView((T?)rowData));
			this.AttributeInfo = attribute;
			this.IsShowFilter = isShowFilter;

			return this;
		}

		/// <summary>
		/// Get cell attribute
		/// </summary>
		/// <returns>Cell attribute</returns>
		public string GetAttribute()
		{
			var attribute = this.AttributeInfo != null
				? ((PropertyInfo[])this.AttributeInfo.GetType().GetProperties())
					.Select(i => $"{i.Name}={i.GetValue(this.AttributeInfo)}")
					.JoinToString(" ")
				: string.Empty;
			return attribute;
		}

		public bool IsShowFilter { get; set; }

		/// <summary>Cell HTML rendering</summary>
		public Func<object?, Task<IHtmlContent>>? RenderCellView { get; set; }

		public dynamic? AttributeInfo { get; set; }
	}

	/// <summary>
	/// Pagination information
	/// </summary>
	/// <param name="PageIndex">Current page index</param>
	/// <param name="PageSize">Search page size</param>
	/// <param name="SearchCount">Search display count</param>
	/// <param name="SearchHitCount">Search hit count</param>
	/// <param name="TotalPage">Total page</param>
	public record PageInfo (int PageIndex, int PageSize, int SearchCount, int SearchHitCount, int TotalPage);
}
