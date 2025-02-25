// Copyright (c) 2025 - Jun Dev. All rights reserved

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
			var srtAttribute = RowAttributes
				.Select(kvp => $"{kvp.Key}=\"{kvp.Value(rowData)}\"")
				.JoinToString(" ");
			return srtAttribute;
		}

		/// <summary>A collection of data per row</summary>
		public IEnumerable<object> DataSource { get; set; } = Array.Empty<object>();

		/// <summary>A collection of column to display</summary>
		public CellInfo[] Columns { get; set; } = Array.Empty<CellInfo>();

		/// <summary>A collection of cells to display</summary>
		public CellInfo[] Cells { get; set; } = Array.Empty<CellInfo>();

		/// <summary>Row attributes</summary>
		public Dictionary<string, Func<object?, string>> RowAttributes { get; set; } = new();

		/// <summary>Returns false if there is no item in <see cref="DataSource"/></summary>
		public bool HasData => DataSource.Any();

		/// <summary>If there is no item in <see cref="DataSource"/>, it will be displayed as a warning message.</summary>
		public string PlaceholderText { get; set; } = string.Empty;

		/// <summary>Paging information</summary>
		public PageInfo? PageInfo { get; set; }
	}

	/// <summary>
	/// An object that includes cell information to render HTML
	/// </summary>
	public sealed class CellInfo
	{
		/// <summary>
		/// Set column information
		/// </summary>
		/// <param name="renderView">A callback to render HTML</param>
		/// <param name="attribute">Column attribute</param>
		/// <param name="sortBy">Sort by key (hide sort if not set)</param>
		/// <returns><see cref="CellInfo"/> class</returns>
		public CellInfo SetColumn(
			Func<object> renderView,
			dynamic? attribute = null,
			string sortBy = "")
		{
			RenderCellView = (rowData) =>
				Task.FromResult<IHtmlContent>(
					new HtmlString(renderView().ToStringOrEmpty()));
			Attribute = attribute;
			SortBy = sortBy;

			return this;
		}

		/// <summary>
		/// Set cell information
		/// </summary>
		/// <typeparam name="T">Type of datasource</typeparam>
		/// <param name="renderView">A callback to render HTML</param>
		/// <param name="attribute">Cell attribute</param>
		/// <returns><see cref="CellInfo"/> class</returns>
		public CellInfo SetCell<T>(
			Func<T?, object> renderView,
			dynamic? attribute = null)
		{
			RenderCellView = (rowData) =>
				Task.FromResult<IHtmlContent>(
					new HtmlString(renderView((T?)rowData).ToStringOrEmpty()));
			Attribute = attribute;

			return this;
		}
		/// <summary>
		/// Set cell information (for asynchronous HTML)
		/// </summary>
		/// <typeparam name="T">Type of datasource</typeparam>
		/// <param name="renderView">A callback to render HTML (for asynchronous)</param>
		/// <param name="attribute">Cell attribute</param>
		/// <returns><see cref="CellInfo"/> class</returns>
		public CellInfo SetCell<T>(
			Func<T?, Task<string>> renderView,
			dynamic? attribute = null)
		{
			RenderCellView = async (rowData) =>
				new HtmlString(await renderView((T?)rowData));
			Attribute = attribute;

			return this;
		}

		/// <summary>
		/// Get cell attribute
		/// </summary>
		/// <returns>Cell attribute</returns>
		public string GetAttribute()
		{
			var attribute = Attribute != null
				? ((PropertyInfo[])Attribute.GetType().GetProperties())
					.Select(i => $"{i.Name}=\"{i.GetValue(Attribute)}\"")
					.JoinToString(" ")
				: string.Empty;
			return attribute;
		}

		/// <summary>Sort by key (set for column only)</summary>
		public string SortBy { get; private set; } = string.Empty;

		/// <summary>Cell HTML rendering</summary>
		public Func<object?, Task<IHtmlContent>>? RenderCellView { get; set; }

		/// <summary>Cell attribute</summary>
		public dynamic? Attribute { get; private set; }
	}

	/// <summary>
	/// Pagination information
	/// </summary>
	/// <param name="PageIndex">Current page index</param>
	/// <param name="PageSize">Search page size</param>
	/// <param name="SearchCount">Search display count</param>
	/// <param name="SearchHitCount">Search hit count</param>
	/// <param name="TotalPage">Total page</param>
	public record PageInfo(
		int PageIndex,
		int PageSize,
		int SearchCount,
		int SearchHitCount,
		int TotalPage);
}
