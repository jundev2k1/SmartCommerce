// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Services
{
	public interface IProductService
	{
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="searchParams">Search parameters</param>
		/// <param name="pageIndex">Page index</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Search result model</returns>
		SearchResultModel<ProductModel> Search(ProductSearchDto searchParams, int pageIndex, int pageSize = Constants.DEFAULT_PAGE_SIZE);

		/// <summary>
		/// Get all product
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="isDeleted">Delete flag of product</param>
		/// <returns>A collection of product</returns>
		ProductModel[] GetAll(string branchId, bool isDeleted = false);

		/// <summary>
		/// Get related products
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>A collection of related product</returns>
		ProductModel[] GetRelatedProducts(string branchId, string productId);

		/// <summary>
		/// Get product
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>product model</returns>
		ProductModel? Get(string branchId, string productId);

		/// <summary>
		/// Insert product
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Insert status</returns>
		bool Insert(ProductModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Update status</returns>
		bool Update(ProductModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		bool Update(string branchId, string productId, Action<Product> updateAction);

		/// <summary>
		/// Update description
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Is success</returns>
		bool UpdateDescription(ProductModel model);

		/// <summary>
		/// Update newest product images
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Actual product image value</returns>
		string? UpdateNewestProductImages(string branchId, string productId);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">product id</param>
		/// <remarks>Update delete flag to "true"</remarks>
		/// <returns>Delete status</returns>
		bool TempDelete(string branchId, string productId);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Delete status</returns>
		bool Delete(string branchId, string productId);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		bool IsExist(string branchId, string productId);
	}
}
