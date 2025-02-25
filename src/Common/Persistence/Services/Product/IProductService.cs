// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace SmartCommerce.Persistence.Services
{
	public interface IProductService
	{
		/// <summary>
		/// Get by criteria
		/// </summary>
		/// <param name="condition">Search condition</param>
		/// <returns>Search result model</returns>
		Task<SearchResultModel<ProductModel>> GetByCriteria(ProductFilterModel condition);

		/// <summary>
		/// Get related products
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>A collection of related product</returns>
		Task<ProductModel[]> GetRelatedProducts(string branchId, string productId);

		/// <summary>
		/// Get product
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>product model</returns>
		Task<ProductModel?> Get(string branchId, string productId);

		/// <summary>
		/// Insert product
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Insert status</returns>
		Task<bool> Insert(ProductModel model);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Update status</returns>
		Task<bool> Update(ProductModel model);
		/// <summary>
		/// Update
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <param name="updateAction">Update action</param>
		/// <returns>Update status</returns>
		Task<bool> Update(string branchId, string productId, Action<Product> updateAction);

		/// <summary>
		/// Update description
		/// </summary>
		/// <param name="model">Product model</param>
		/// <returns>Is success</returns>
		Task<bool> UpdateDescription(ProductModel model);

		/// <summary>
		/// Update newest product images
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Actual product image value</returns>
		Task<string?> UpdateNewestProductImages(string branchId, string productId);

		/// <summary>
		/// Delete temporary
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">product id</param>
		/// <remarks>Update delete flag to "true"</remarks>
		/// <returns>Delete status</returns>
		Task<bool> TempDelete(string branchId, string productId);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Delete status</returns>
		Task<bool> Delete(string branchId, string productId);

		/// <summary>
		/// Check is exist
		/// </summary>
		/// <param name="branchId">Branch id</param>
		/// <param name="productId">Product id</param>
		/// <returns>Is exist?</returns>
		Task<bool> IsExist(string branchId, string productId);
	}
}
